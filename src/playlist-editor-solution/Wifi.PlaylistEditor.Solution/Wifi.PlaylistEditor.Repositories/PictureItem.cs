using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.Repositories
{
    public class PictureItem : IPlaylistItem
    {
        private readonly string _filePath; 
        private string _title;
        private Image _thumbnail;

        public PictureItem(string filePath)
        {
            _filePath = filePath;
            _title = Path.GetFileNameWithoutExtension(_filePath);
            _thumbnail = ScaleImage(Image.FromFile(_filePath), 125, 125);
        }

        private Bitmap ScaleImage(Image bmp, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / bmp.Width;
            var ratioY = (double)maxHeight / bmp.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(bmp.Width * ratio);
            var newHeight = (int)(bmp.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(bmp, 0, 0, newWidth, newHeight);

            return newImage;
        }

        public string Title { get => _title; }
        public string Artist { get => "Unknown"; }
        public TimeSpan Duration { get => TimeSpan.FromSeconds(10); }
        public string FilePath { get => _filePath; }
        public Image Thumbnail { get => _thumbnail; }
    }
}
