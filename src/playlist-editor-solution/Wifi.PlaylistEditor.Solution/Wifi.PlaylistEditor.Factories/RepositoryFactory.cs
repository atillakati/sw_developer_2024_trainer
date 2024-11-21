using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wifi.PlaylistEditor.Core;
using Wifi.PlaylistEditor.Repositories;

namespace Wifi.PlaylistEditor.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;
        private readonly List<IPlaylistRepository> _availableTypes;

        public RepositoryFactory(IPlaylistFactory playlistFactory, 
                                 IPlaylistItemFactory playlistItemFactory)
        {
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;

            //create available types list
            //Update list here for future types!!!
            _availableTypes = new List<IPlaylistRepository>
            {
                new M3uRepository(_playlistFactory, _playlistItemFactory),
                new PlsRepository(_playlistFactory, _playlistItemFactory),
                new WplRepository(_playlistFactory, _playlistItemFactory),
                new ZplRepository(_playlistFactory, _playlistItemFactory),
                //...here!!
            };
        }

        public IEnumerable<IFileTypeInfo> AvailableTypes => _availableTypes;

        public IPlaylistRepository Create(string filePath)
        {            
            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            var extension = Path.GetExtension(filePath).ToLower();

            return _availableTypes.FirstOrDefault(x => x.Extension == extension);            
        }
    }
}
