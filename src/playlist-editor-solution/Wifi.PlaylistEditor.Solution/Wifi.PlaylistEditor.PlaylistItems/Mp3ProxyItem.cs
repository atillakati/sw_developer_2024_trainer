using Discogs.ApiClient;
using Discogs.ApiClient.ApiModel.Dto;
using Discogs.ApiClient.ApiModel.Dto.Requests.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.PlaylistItems
{
    public class Mp3ProxyItem : IPlaylistItem, IRefreshableItem
    {
        private readonly string _filePath;
        private readonly DiscogsApiClient _client;
        private Mp3Item _realItem;
        private Image _thumbnail;

        public event EventHandler ItemUpdated;

        internal Mp3ProxyItem() { }

        public Mp3ProxyItem(string filePath)
        {
            _filePath = filePath;
            _realItem = new Mp3Item(_filePath);

            var credentials = DiscogsApiClientCredentials.FromToken(
                                                Environment.GetEnvironmentVariable("MY_DISCOGS_TOKEN"));
            var environment = DiscogsApiClientEnvironment.CreateDefault(credentials);
            _client = DiscogsApiClient.Create(environment);


            if (_realItem.Thumbnail != null)
            {
                _thumbnail = _realItem.Thumbnail;
            }
            else
            {
                //hier soll nun das Internet gefragt (!) werden...
                _thumbnail = Image.FromStream(new MemoryStream(Resource.please_wait));
                Task.Run(GetWebThumbnail);
            }
        }

        
        public string Title => _realItem.Title;

        public string Artist => _realItem.Artist;

        public TimeSpan Duration => _realItem.Duration;

        public string FilePath => _realItem.FilePath;

        public Image Thumbnail => _thumbnail;

        public string Extension => ".mp3";

        public string Description => "MP3 audio files (with discogs lookup support)";

        public override string ToString()
        {
            return _realItem.ToString();
        }


        private async Task GetWebThumbnail()
        {
            var thumbUrl = string.Empty;

            //start search
            var db = _client.Database;
            var searchResults = await db.Search(new DatabaseSearchParams
            {
                Artist = _realItem.Artist,
                Title = _realItem.Title,
                Type = DiscogsSearchEntityType.Release
            });

            //retrieve the right release from search result
            foreach (var release in searchResults.Releases)
            {
                if (release.Title.Contains(_realItem.Title))
                {
                    thumbUrl = release.Thumb;
                    break;
                }
            }

            //check thumbnail Url, download image
            if (!string.IsNullOrEmpty(thumbUrl))
            {
                _thumbnail = await DownloadImageFromWeb(thumbUrl);
                if (_thumbnail != null)
                {
                    _thumbnail = _thumbnail.ResizeAndFill(125, 125, Color.White, true);
                }
            }
            else
            {
                _thumbnail = null;
            }

            //fire refresh me event
            ItemUpdated?.Invoke(this, EventArgs.Empty);
        }

        private async Task<Image> DownloadImageFromWeb(string urlToDownload)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var imageBytes = await client.GetByteArrayAsync(urlToDownload);
                    return Image.FromStream(new MemoryStream(imageBytes));
                }
                catch
                {
                    return null;
                }
            }
        }

    }
}
