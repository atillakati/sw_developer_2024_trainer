using System;

namespace Wifi.PlaylistEditor.Core
{
    public interface IPlaylistFactory
    {
        IPlaylist Create(string title, string author);

        IPlaylist Create(string title, string author, DateTime createDate);
    }
}
