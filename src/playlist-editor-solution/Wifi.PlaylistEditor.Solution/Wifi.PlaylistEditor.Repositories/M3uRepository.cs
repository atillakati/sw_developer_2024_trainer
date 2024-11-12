using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.Repositories
{
    public class M3uRepository : IPlaylistRepository
    {
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public M3uRepository(IPlaylistItemFactory playlistItemFactory)
        {
            _playlistItemFactory = playlistItemFactory;
        }

        public string Description => "M3U playlist file format";

        public string Extension => ".m3u";
        

        public void Save(IPlaylist playlist, string filePath)
        {
            var m3uPlaylist = new M3uPlaylist();
            m3uPlaylist.IsExtended = true;

            //add meta information
            m3uPlaylist.Comments.Add($"#Title:{playlist.Title}");

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
            string text = content.ToText(m3uPlaylist);
            
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

            //open file and convert content into M3uPlaylist type
            using (StreamReader sr = new StreamReader(filePath))
            {
                m3uPlaylist = content.GetFromStream(sr.BaseStream);
            }            

            //create Playlist instance
            var playlist = new Playlist("Titel", "Gandalf");

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
    }
}
