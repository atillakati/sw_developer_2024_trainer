using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.Factories
{
    public class DynamicRepositoryFactory : IRepositoryFactory
    {
        private readonly IEnumerable<IPlaylistRepository> _playlistRepositories;

        public DynamicRepositoryFactory(IEnumerable<IPlaylistRepository> playlistRepositories)
        {
            _playlistRepositories = playlistRepositories;
        }


        public IEnumerable<IFileTypeInfo> AvailableTypes => _playlistRepositories;

        public IPlaylistRepository Create(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            var extension = Path.GetExtension(filePath).ToLower();

            return _playlistRepositories.FirstOrDefault(x => x.Extension == extension);
        }
    }
}
