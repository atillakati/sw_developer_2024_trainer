using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Core;
using Wifi.PlaylistEditor.PlaylistItems;

namespace Wifi.PlaylistEditor.Factories
{
    public class PlaylistItemFactory : IPlaylistItemFactory
    {
        public IPlaylistItem Create(string filePath)
        {
            IPlaylistItem newItem = null;

            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            var extension = Path.GetExtension(filePath);

            switch (extension)
            {
                case ".mp3":
                    newItem = new Mp3Item(filePath);
                    break;

                case ".jpg":
                    newItem = new PictureItem(filePath);
                    break;

                default:
                    throw new NotImplementedException($"Dateityp {extension} wird leider nicht unterstützt.");                   
            }

            return newItem;
        }
    }
}
