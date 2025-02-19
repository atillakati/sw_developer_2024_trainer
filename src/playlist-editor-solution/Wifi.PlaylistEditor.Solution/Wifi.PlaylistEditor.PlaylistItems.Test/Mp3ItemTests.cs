﻿using NUnit.Framework;
using System;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.PlaylistItems.Test
{
    [TestFixture]
    public class Mp3ItemTests
    {
        private IPlaylistItem _fixture;

        [SetUp]
        public void Init()
        {
            _fixture = new Mp3Item("Assets/DemoFile.mp3");
        }

        [Test]
        public void Title_get()
        {
            Assert.That(_fixture.Title, Is.EqualTo("Grenade"));
        }

        [Test]
        public void Artist_get()
        {
            Assert.That(_fixture.Artist, Is.EqualTo("Bruno Mars"));
        }

        [Test]
        public void Duration_get()
        {
            Assert.That(_fixture.Duration, Is.EqualTo(TimeSpan.FromSeconds(222)));
        }

        [Test]
        public void FilePath_get()
        {
            Assert.That(_fixture.FilePath, Is.EqualTo("Assets/DemoFile.mp3"));
        }

        [Test]
        public void Thumbnail_get()
        {
            Assert.That(_fixture.Thumbnail, Is.Not.Null);
        }
    }
}
