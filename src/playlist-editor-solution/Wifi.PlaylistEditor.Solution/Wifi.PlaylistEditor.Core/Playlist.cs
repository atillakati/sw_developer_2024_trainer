using System;
using System.Collections.Generic;
using System.Linq;

namespace Wifi.PlaylistEditor.Core
{
    public class Playlist : IPlaylist
    {
        private string _title;
        private string _author;
        private DateTime _dateOfCreation;
        private List<IPlaylistItem> _items;

        public Playlist(string title, string author)
            : this(title, author, DateTime.Now) { }

        public Playlist(string title, string author, DateTime dateOfCreation)
        {
            _title = title;
            _author = author;
            _dateOfCreation = dateOfCreation;

            _items = new List<IPlaylistItem>();
        }

        public IEnumerable<IPlaylistItem> Items
        {
            get { return _items; }
        }

        public TimeSpan Duration
        {
            get
            {
                if (_items.Any())
                {
                    var duration = _items.Aggregate(TimeSpan.Zero, (sum, x) => sum += x.Duration);
                    return duration;
                }

                return TimeSpan.Zero;
            }
        }

        public DateTime DateOfCreation
        {
            get { return _dateOfCreation; }
        }

        public string Author
        {
            get { return _author; }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _title = value;
                }
            }
        }


        public void Add(IPlaylistItem item)
        {
            if (item == null)
            {
                return;
            }

            _items.Add(item);
        }

        public void Remove(IPlaylistItem item)
        {
            _items.Remove(item);
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}
