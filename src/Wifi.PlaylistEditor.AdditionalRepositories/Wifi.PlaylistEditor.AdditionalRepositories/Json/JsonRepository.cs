using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Wifi.PlaylistEditor.AdditionalRepositories.Json.Entities;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.AdditionalRepositories.Json
{
    public class JsonRepository : IPlaylistRepository
    {
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public JsonRepository(IPlaylistFactory playlistFactory, 
                              IPlaylistItemFactory playlistItemFactory)
        {
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
        }

        public string Extension => ".json";

        public string Description => "Default Playlist json editor format";

        public IPlaylist Load(string filePath)
        {
            var json = string.Empty;

            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            //read from file
            using(var sr = new StreamReader(filePath))
            {
                json = sr.ReadToEnd();
            }

            //deserialize
            var entityPlaylist = JsonConvert.DeserializeObject<PlaylistEntity>(json);

            //convert domain => entity object
            var playlist = _playlistFactory.Create(
                 entityPlaylist.Title,
                 entityPlaylist.Author,
                 DateTime.ParseExact(entityPlaylist.CreateDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            );

            foreach (var item in entityPlaylist.Items)
            {
                var playlistItem = _playlistItemFactory.Create(item.Path);
                if(playlistItem != null)
                {
                    playlist.Add(playlistItem);
                }
            }

            return playlist;
        }

        public void Save(IPlaylist playlist, string filePath)
        {
            if(string.IsNullOrEmpty(filePath) || playlist == null)
            {
                return;
            }

            //convert domain => entity object
            var playlistEntity = new PlaylistEntity
            {
                Author = playlist.Author,
                Title = playlist.Title,
                ClientApp = "WIFI Playlist Editor",
                CreateDate = playlist.DateOfCreation.ToString("yyyy-MM-dd"),
                FileVersion = 1,
                Items = playlist.Items.Select(x => new ItemEntity 
                                                   { 
                                                        Path = x.FilePath, 
                                                        Duration = x.Duration.ToString() 
                                                    })
                                      .ToArray()
            };

            //serialize
            string json = JsonConvert.SerializeObject(playlistEntity);

            //write to file
            using(var sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(json);
            }
        }
    }
}
