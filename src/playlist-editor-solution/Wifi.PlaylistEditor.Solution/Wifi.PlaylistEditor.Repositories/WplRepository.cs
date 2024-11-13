using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.IO;
using System.Linq;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.Repositories
{
    public class WplRepository : IPlaylistRepository
    {
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;


        public WplRepository(IPlaylistFactory playlistFactory, IPlaylistItemFactory playlistItemFactory)
        {
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
        }


        public string Description => "WPL playlist file format";

        public string Extension => ".wpl";


        public void Save(IPlaylist playlist, string filePath)
        {
            if (playlist == null)
            {
                return;
            }

            var wplPlaylist = new WplPlaylist
            {
                Title = playlist.Title,
                Author = playlist.Author,
                TotalDuration = playlist.Duration,
                FileName = Path.GetFileName(filePath),
                Generator = "WIFI Playlist Editor",
                Path = filePath,
                ItemCount = playlist.Items.Count(),
                Guid = Guid.NewGuid().ToString(),
            };
            
            
            //add items into m3u playlist
            foreach (var item in playlist.Items)
            {
                wplPlaylist.PlaylistEntries.Add(new WplPlaylistEntry()
                {
                    Duration = item.Duration,
                    Path = item.FilePath,
                    TrackTitle = item.Title,
                    TrackArtist = item.Artist,
                });
            }

            var content = new WplContent();
            var text = content.ToText(wplPlaylist);

            //write content into file
            using (var sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(text);
            }
        }

        public IPlaylist Load(string filePath)
        {
            WplPlaylist wplPlaylist;
            var content = new WplContent();

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath) || Path.GetExtension(filePath) != Extension)
            {
                return null;
            }

            //open file and convert content into M3uPlaylist type
            using (var sr = new StreamReader(filePath))
            {
                wplPlaylist = content.GetFromStream(sr.BaseStream);
            }

            //create Playlist instance
            var playlist = _playlistFactory.Create(wplPlaylist.Title, wplPlaylist.Author, File.GetCreationTime(filePath));
            
            //add item instances
            foreach (var wplItem in wplPlaylist.PlaylistEntries)
            {
                var item = _playlistItemFactory.Create(wplItem.Path);
                if (item != null)
                {
                    playlist.Add(item);
                }
            }

            return playlist;
        }
    }
}
