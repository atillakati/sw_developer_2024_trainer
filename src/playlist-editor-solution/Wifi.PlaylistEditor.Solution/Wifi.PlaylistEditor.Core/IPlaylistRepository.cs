using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Core
{
    public interface IPlaylistRepository
    {
        string Description { get; }
        string Extension { get; }

        IPlaylist Load(string filePath);

        void Save(IPlaylist playlist, string filePath);
    }
}
