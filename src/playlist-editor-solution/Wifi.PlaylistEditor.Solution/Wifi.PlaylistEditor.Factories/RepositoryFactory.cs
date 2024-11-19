using System;
using System.IO;
using Wifi.PlaylistEditor.Core;
using Wifi.PlaylistEditor.Repositories;

namespace Wifi.PlaylistEditor.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;


        public RepositoryFactory(IPlaylistFactory playlistFactory, 
                                 IPlaylistItemFactory playlistItemFactory)
        {
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
        }


        public IPlaylistRepository Create(string filePath)
        {
            IPlaylistRepository repository = null;

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                return null;
            }

            var extension = Path.GetExtension(filePath).ToLower();
            switch (extension)
            {
                case ".m3u":
                    repository = new M3uRepository(_playlistFactory, _playlistItemFactory);
                    break;

                case ".pls":
                    repository = new PlsRepository(_playlistFactory, _playlistItemFactory);
                    break;

                case ".wpl":
                    repository = new WplRepository(_playlistFactory, _playlistItemFactory);
                    break;

                case ".zpl":
                    repository = new ZplRepository(_playlistFactory, _playlistItemFactory);
                    break;

                default:
                    break;
            }

            return repository;
        }
    }
}
