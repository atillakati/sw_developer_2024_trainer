using System;
using System.Collections.Generic;
using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System.IO;
using System.Linq;
using Wifi.PlaylistEditor.Core;
using System.Globalization;

namespace Wifi.PlaylistEditor.Repositories
{
    public class M3uRepository : IPlaylistRepository
    {
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;


        public M3uRepository(IPlaylistFactory playlistFactory, IPlaylistItemFactory playlistItemFactory)
        {
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
        }


        public string Description => "M3U playlist file format";

        public string Extension => ".m3u";
        

        public void Save(IPlaylist playlist, string filePath)
        {
            var m3uPlaylist = new M3uPlaylist();
            m3uPlaylist.IsExtended = true;

            //add meta information
            m3uPlaylist.Comments.Add($"Title:{playlist.Title}");
            m3uPlaylist.Comments.Add($"Author:{playlist.Author}");
            m3uPlaylist.Comments.Add($"CreateDate:{playlist.DateOfCreation:dd-MM-yyyy}");

            //add items into m3u playlist
            foreach (var item in playlist.Items)
            {
                m3uPlaylist.PlaylistEntries.Add(new M3uPlaylistEntry()
                {                    
                    AlbumArtist = item.Artist,                    
                    Duration = item.Duration,
                    Path = item.FilePath,
                    Title = item.Title
                });
            }
            
            var content = new M3uContent();
            var text = content.ToText(m3uPlaylist);
            
            //write content into file
            using(var sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(text);
            }            
        }

        public IPlaylist Load(string filePath)
        {
            M3uPlaylist m3uPlaylist;
            var content = new M3uContent();

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath) || Path.GetExtension(filePath) != Extension)
            {
                return null;
            }

            //open file and convert content into M3uPlaylist type
            using (var sr = new StreamReader(filePath))
            {
                m3uPlaylist = content.GetFromStream(sr.BaseStream);
            }            

            //extract meta information
            var keyValueList = ExtractComments(m3uPlaylist.PlaylistEntries.Where(x => x.Comments.Any())
                                                                          .Select(x => x.Comments)
                                                                          .FirstOrDefault());
            //create Playlist instance
            var playlist = _playlistFactory.Create(keyValueList["Title"], 
                                                   keyValueList["Author"], 
                                                   DateTime.ParseExact(keyValueList["CreateDate"], "dd-MM-yyyy", CultureInfo.InvariantCulture));

            //add item instances
            foreach (var m3uItem in m3uPlaylist.PlaylistEntries)
            {
                var item = _playlistItemFactory.Create(m3uItem.Path);
                if (item != null)
                {
                    playlist.Add(item);
                }
            }

            return playlist;
        }

        private Dictionary<string, string> ExtractComments(IEnumerable<string> comments)
        {
            var keyValuePairs = new Dictionary<string, string>();

            if (comments == null || !comments.Any())
            {
                return new Dictionary<string, string>();
            }

            foreach (var commentLine in comments)  
            {
                var parts = commentLine.Split(':');
                if (parts.Length == 2)
                {
                    var key = parts[0].Trim();
                    if (!keyValuePairs.ContainsKey(key))
                    {
                        keyValuePairs.Add(key, parts[1].Trim());
                    }
                    else
                    {
                        //overwrite existing key values
                        keyValuePairs[key] = parts[1].Trim();
                    }
                }
            }

            return keyValuePairs;
        }
    }
}
