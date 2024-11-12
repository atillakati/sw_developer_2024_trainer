using System;
using System.Collections.Generic;

namespace Wifi.PlaylistEditor.Core
{
    public interface IPlaylist
    {
        string Author { get; }
        DateTime DateOfCreation { get; }
        TimeSpan Duration { get; }
        IEnumerable<IPlaylistItem> Items { get; }
        string Title { get; set; }

        void Add(IPlaylistItem item);
        void Clear();
        void Remove(IPlaylistItem item);
    }
}