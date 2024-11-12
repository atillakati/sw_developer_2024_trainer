using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.Repositories.Test
{
    [TestFixture]
    public class M3uRepositoryTests
    {
        private IPlaylistRepository _fixture;

        private Mock<IPlaylist> _mockedPlaylist;
        private Mock<IPlaylistItem> _mockedItem1;
        private Mock<IPlaylistItem> _mockedItem2;

        [SetUp]
        public void Init()
        {
            _fixture = new M3uRepository(Mock.Of<IPlaylistItemFactory>());

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

            _mockedPlaylist.Setup(x => x.Items).Returns(new IPlaylistItem[] {_mockedItem1.Object,
                                                                             _mockedItem2.Object });
        }

        [Test]
        [Ignore("Only for debugging")]
        public void Save()
        {
            _fixture.Save(_mockedPlaylist.Object, "TestDemoPlaylist.m3u");
        }
    }
}
