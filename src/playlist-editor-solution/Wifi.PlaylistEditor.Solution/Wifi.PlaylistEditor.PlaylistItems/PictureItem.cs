using System;
using System.CodeDom;
using System.Drawing;
using System.IO;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.PlaylistItems
{
    public class PictureItem : IPlaylistItem
    {
        private readonly string _filePath; 
        private string _title;
        private Image _thumbnail;

        internal PictureItem() { }

        public PictureItem(string filePath)
        {
            _filePath = filePath;
            _title = Path.GetFileNameWithoutExtension(_filePath);
            _thumbnail = Image.FromFile(_filePath)
                              .ResizeAndFill(125, 125, Color.White);
        }        

        public string Title { get => _title; }
        public string Artist { get => "Unknown"; }
        public TimeSpan Duration { get => TimeSpan.FromSeconds(10); }
        public string FilePath { get => _filePath; }
        public Image Thumbnail { get => _thumbnail; }

        public string Description { get => "JPG Picture file"; }
        public string Extension { get => ".jpg"; }

        public override string ToString()
        {
            return $"{_title}";
        }
    }
}
