using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System.IO;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.Repositories
{
    public class PlsRepository : IPlaylistRepository
    {
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;


        public PlsRepository(IPlaylistFactory playlistFactory, IPlaylistItemFactory playlistItemFactory)
        {
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
        }


        public string Description => "PLS playlist file format";

        public string Extension => ".pls";


        public void Save(IPlaylist playlist, string filePath)
        {
            if (playlist == null)
            {
                return;
            }

            var plsPlaylist = new PlsPlaylist
            {
                Version = 2,
                FileName = Path.GetFileName(filePath),
                Path = filePath,
            };

            var counter = 1;

            //add items into m3u playlist
            foreach (var item in playlist.Items)
            {
                plsPlaylist.PlaylistEntries.Add(new PlsPlaylistEntry()
                {
                    Path = item.FilePath,
                    Length = item.Duration,
                    Title = item.Title,
                    Nr  = counter++
                });
            }

            var content = new PlsContent();
            var text = content.ToText(plsPlaylist);

            //write content into file
            using (var sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(text);
            }
        }

        public IPlaylist Load(string filePath)
        {
            PlsPlaylist plsPlaylist;
            var content = new PlsContent();

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath) || Path.GetExtension(filePath) != Extension)
            {
                return null;
            }

            //open file and convert content into M3uPlaylist type
            using (var sr = new StreamReader(filePath))
            {
                plsPlaylist = content.GetFromStream(sr.BaseStream);
            }

            //create Playlist instance
            var playlist = _playlistFactory.Create(Path.GetFileNameWithoutExtension(filePath), 
                                                   "Unknown", File.GetCreationTime(filePath));
            
            //add item instances
            foreach (var plsItem in plsPlaylist.PlaylistEntries)
            {
                var item = _playlistItemFactory.Create(plsItem.Path);
                if (item != null)
                {
                    playlist.Add(item);
                }
            }

            return playlist;
        }
    }
}
