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
        private Mock<IPlaylistItem> _mockedItem2;

        [SetUp]
        public void Init()
        {
            _fixture = new Playlist("Demo Playlist", "Testing");

            //setup mocked item
            _mockedItem = new Mock<IPlaylistItem>();
            _mockedItem.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(53));
            _mockedItem.Setup(x => x.Title).Returns("Demo Title 1");

            _mockedItem2 = new Mock<IPlaylistItem>();
            _mockedItem2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(23));
            _mockedItem2.Setup(x => x.Title).Returns("Demo Title 2");
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
            _fixture.Add(_mockedItem2.Object);

            //act
            var result = _fixture.Duration;

            //assert
            Assert.That(result, Is.EqualTo(TimeSpan.FromSeconds(76)));
        }

        [Test]
        [TestCaseSource(nameof(TitleSetTestCases))]
        public void Title_set(int id, string newValue, string expectedValue)
        {
            //arrange                  

            //act
            _fixture.Title = newValue;
            var result = _fixture.Title;

            //assert
            Assert.That(result, Is.EqualTo(expectedValue), $"Testcase {id} failed.");
        }

        private static object[] TitleSetTestCases()
        {
            return new object[]
            {
                new object[] { 1, "Gandalf", "Gandalf"},
                new object[] { 2, string.Empty, "Demo Playlist"},
                new object[] { 3, null, "Demo Playlist"},
            };
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
        public void DateOfCreation_get()
        {
            //arrange            
            var dateOfCreation = new DateTime(2024, 11, 8);
            var fixture = new Playlist("Demo Playlist", "Testing", dateOfCreation);

            //act
            var result = fixture.DateOfCreation;

            //assert
            Assert.That(result, Is.EqualTo(dateOfCreation));
        }

        [Test]
        public void Author_get()
        {
            //arrange            

            //act
            var result = _fixture.Author;

            //assert
            Assert.That(result, Is.EqualTo("Testing"));
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
        public void Remove()
        {
            //arrange
            _fixture.Add(_mockedItem.Object);
            _fixture.Add(_mockedItem2.Object);

            //act
            _fixture.Remove(_mockedItem.Object);

            //assert
            Assert.That(_fixture.Items.Count, Is.EqualTo(1));
            Assert.That(_fixture.Items.FirstOrDefault(), Is.Not.Null);
            Assert.That(_fixture.Items.FirstOrDefault()?.Title, Is.EqualTo("Demo Title 2"));
        }

        [Test]
        public void Remove_null()
        {
            //arrange
            _fixture.Add(_mockedItem.Object);
            _fixture.Add(_mockedItem2.Object);

            //act
            _fixture.Remove(null);

            //assert
            Assert.That(_fixture.Items.Count, Is.EqualTo(2));
        }

        [Test]
        public void Remove_NotExistingItem()
        {
            //arrange
            _fixture.Add(_mockedItem.Object);

            //act
            _fixture.Remove(_mockedItem2.Object);

            //assert
            Assert.That(_fixture.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void Clear()
        {
            //arrange
            _fixture.Add(_mockedItem.Object);
            _fixture.Add(_mockedItem2.Object);
            var itemCount = _fixture.Items.Count();

            //act
            _fixture.Clear();

            //assert
            Assert.That(itemCount, Is.EqualTo(2));
            Assert.That(_fixture.Items.Any(), Is.False);
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
