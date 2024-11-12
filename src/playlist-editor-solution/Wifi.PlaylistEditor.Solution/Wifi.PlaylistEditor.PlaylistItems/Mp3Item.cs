using Id3;
using System;
using System.Drawing;
using System.IO;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.PlaylistItems
{
    public class Mp3Item : IPlaylistItem
    {
        private string _title;
        private string _artist;
        private TimeSpan _duration;
        private string _filePath;
        private Image _thumbnail;

        public Mp3Item(string filePath)
        {
            var mp3 = new Mp3(filePath);
            var id3Tag = mp3.GetTag(Id3TagFamily.Version2X);

            _title = id3Tag.Title;
            _artist = id3Tag.Artists;
            _duration = mp3.Audio.Duration;
            _filePath = filePath;
            _thumbnail = GetThumbnail(id3Tag);
        }        

        public string Title { get => _title; }
        public string Artist { get => _artist; }
        public TimeSpan Duration { get => _duration; }
        public string FilePath { get => _filePath; }
        public Image Thumbnail { get => _thumbnail; }

        private Image GetThumbnail(Id3Tag id3Tag)
        {
            if (id3Tag.Pictures == null || id3Tag.Pictures.Count == 0)
            {
                return null;
            }

            var thumbnail = Image.FromStream(new MemoryStream(id3Tag.Pictures[0].PictureData));
            return thumbnail;
        }
    }
}
