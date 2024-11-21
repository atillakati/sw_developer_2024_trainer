using System.Collections.Generic;

namespace Wifi.PlaylistEditor.Core
{
    public interface IPlaylistItemFactory
    {
        IEnumerable<IFileTypeInfo> AvailableTypes { get; }

        IPlaylistItem Create(string filePath);
    }
}
