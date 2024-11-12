using NUnit.Framework;
using System;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.PlaylistItems.Test
{
    [TestFixture]
    public class PictureItemTests
    {
        private IPlaylistItem _fixture;

        [SetUp]
        public void Init()
        {
            _fixture = new PictureItem("Assets/Debugging.jpg");
        }

        [Test]
        public void Title_get()
        {
            Assert.That(_fixture.Title, Is.EqualTo("Debugging"));
        }

        [Test]
        public void Artist_get()
        {
            Assert.That(_fixture.Artist, Is.EqualTo("Unknown"));
        }

        [Test]
        public void Duration_get()
        {
            Assert.That(_fixture.Duration, Is.EqualTo(TimeSpan.FromSeconds(10)));
        }

        [Test]
        public void FilePath_get()
        {
            Assert.That(_fixture.FilePath, Is.EqualTo("Assets/Debugging.jpg"));
        }

        [Test]
        public void Thumbnail_get()
        {
            Assert.That(_fixture.Thumbnail, Is.Not.Null);
            Assert.That(_fixture.Thumbnail.Height, Is.EqualTo(69));
            Assert.That(_fixture.Thumbnail.Width, Is.EqualTo(125));
        }
    }
}
