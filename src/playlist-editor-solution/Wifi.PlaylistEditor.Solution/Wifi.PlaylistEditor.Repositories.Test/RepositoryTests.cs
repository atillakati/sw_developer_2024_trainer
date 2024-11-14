using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.Repositories.Test
{
    
    [TestFixture(typeof(M3uRepository))]
    [TestFixture(typeof(WplRepository))]
    [TestFixture(typeof(ZplRepository))]
    [TestFixture(typeof(PlsRepository))]
    public class RepositoryTests<T> where T : IPlaylistRepository
    {
        private IPlaylistRepository _fixture;

        private Mock<IPlaylist> _mockedPlaylist;
        private Mock<IPlaylistItem> _mockedItem1;
        private Mock<IPlaylistItem> _mockedItem2;
        private Mock<IPlaylistFactory> _mockedPlaylistFactory;
        private Mock<IPlaylistItemFactory> _mockedPlaylistItemFactory;


        [SetUp]
        public void Init()
        {
            _mockedPlaylistItemFactory = new Mock<IPlaylistItemFactory>();
            _mockedPlaylistFactory = new Mock<IPlaylistFactory>();

            _fixture = (T)Activator.CreateInstance(typeof(T), _mockedPlaylistFactory.Object, 
                                                              _mockedPlaylistItemFactory.Object);
            
            _mockedPlaylist = new Mock<IPlaylist>();
            _mockedItem1 = new Mock<IPlaylistItem>();
            _mockedItem2 = new Mock<IPlaylistItem>();

            _mockedItem1.Setup(x => x.Artist).Returns("Demo Artist 1");
            _mockedItem1.Setup(x => x.Title).Returns("Title A");
            _mockedItem1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(42));
            _mockedItem1.Setup(x => x.FilePath).Returns(@"c:\tmp\demoSong.mp3");

            _mockedItem2.Setup(x => x.Artist).Returns("Ein Artist");
            _mockedItem2.Setup(x => x.Title).Returns("Ein demo Titel");
            _mockedItem2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(24));
            _mockedItem2.Setup(x => x.FilePath).Returns("SuperDemoSong.mp3");

            _mockedPlaylist.Setup(x => x.Title).Returns("My greatest hits 2024");
            _mockedPlaylist.Setup(x => x.Author).Returns("DJ Gandalf");
            _mockedPlaylist.Setup(x => x.DateOfCreation).Returns(new DateTime(2024,7,15));
            _mockedPlaylist.Setup(x => x.Items).Returns(new [] {_mockedItem1.Object, _mockedItem2.Object });
        }

        [Test]
        //[Ignore("Only for debugging")]
        public void Save()
        {
            _fixture.Save(_mockedPlaylist.Object, "TestDemoPlaylist" + _fixture.Extension );
        }

        [Test]
        [TestCaseSource(nameof(LoadTestCases))]
        //[Ignore("Only for debugging")]
        public void Load(int id, string filename, bool addExtension, Times playlistFactoryCount, Times itemFactoryCount)
        {
            //arrange
            _fixture.Save(_mockedPlaylist.Object, "TestDemoPlaylist" + _fixture.Extension);

            //act
            _fixture.Load(filename + (addExtension ? _fixture.Extension : string.Empty));

            //assert
            _mockedPlaylistFactory.Verify(x => x.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()), playlistFactoryCount);
            _mockedPlaylistItemFactory.Verify(x => x.Create(It.IsAny<string>()), itemFactoryCount);
        }

        private static IEnumerable<object> LoadTestCases()
        {
            return new object[]
            {
                new object[] { 1, "TestDemoPlaylist", true, Times.Once(), Times.Exactly(2)},
                new object[] { 2, "", false, Times.Never(), Times.Never()},
                new object[] { 3, null, false, Times.Never(), Times.Never()},
                new object[] { 4, "TestDemoPlaylist.xyz", false, Times.Never(), Times.Never()},
                new object[] { 5, "PlaylistsNET.dll", false, Times.Never(), Times.Never()}
            };
        }
    }
}
