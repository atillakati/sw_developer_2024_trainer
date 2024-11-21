using System.Collections.Generic;

namespace Wifi.PlaylistEditor.Core
{
    public interface IRepositoryFactory
    {
        IEnumerable<IFileTypeInfo> AvailableTypes { get; }

        IPlaylistRepository Create(string filePath);
    }
}
