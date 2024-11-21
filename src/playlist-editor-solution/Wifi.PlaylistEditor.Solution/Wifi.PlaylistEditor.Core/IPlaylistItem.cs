using System;
using System.Drawing;

namespace Wifi.PlaylistEditor.Core
{
    public interface IPlaylistItem : IFileTypeInfo
    {
        string Title { get; }

        string Artist { get; }

        TimeSpan Duration { get; }

        string FilePath { get; }

        /// <summary>
        /// Thumbnail of picture information max. 125x125 px
        /// </summary>
        Image Thumbnail { get; }
    }
}
