using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Core.Test
{
    [TestFixture]
    public class PlaylistTests
    {
        private Playlist _fixture;
        private Mock<IPlaylistItem> _mockedItem;

        [SetUp]
        public void Init()
        {
            _fixture = new Playlist("Demo Playlist", "Testing");

            //setup mocked item
            _mockedItem = new Mock<IPlaylistItem>();
            _mockedItem.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(53));
        }

        [Test]
        public void Duration_get_NoItems()
        {
            var result = _fixture.Duration;

            Assert.That(result, Is.EqualTo(TimeSpan.Zero));
        }

        [Test]
        public void Duration_get()
        {
            //arrange
            _fixture.Add(_mockedItem.Object);
            _fixture.Add(_mockedItem.Object);

            //act
            var result = _fixture.Duration;

            //assert
            Assert.That(result, Is.EqualTo(TimeSpan.FromSeconds(106)));
        }

        [Test]
        public void Title_set()
        {
            //arrange
            var newTitle = "Gandalf";            

            //act
            _fixture.Title = newTitle;
            var result = _fixture.Title;

            //assert
            Assert.That(result, Is.EqualTo(newTitle));
        }

        [Test]
        public void Title_get()
        {
            //arrange            

            //act
            var result = _fixture.Title;

            //assert
            Assert.That(result, Is.EqualTo("Demo Playlist"));
        }

        [Test]
        public void FirstTest()
        {
            //arrange
            int erg = 0;

            //act
            erg = 5 + 6;

            //assert
            Assert.That(erg, Is.EqualTo(11));
        }

        [Test]
        public void Add()
        {
            //arrange

            //act
            _fixture.Add(_mockedItem.Object);

            //assert
            Assert.That(_fixture.Items.Any(), Is.True);
        }

        [Test]
        public void Add_null()
        {
            //arrange

            //act
            _fixture.Add(null);

            //assert
            Assert.That(_fixture.Items.Any(), Is.False);
        }
    }
}
