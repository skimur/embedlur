﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Embedlur.Tests
{
    [TestFixture]
    public class FlickrProviderTests
    {
        private IProvider _provider;

        [Test]
        public void Can_serve_urls()
        {
            Assert.That(_provider.CanServeUrl("https://www.flickr.com/photos/oneredballoon/22450013589/in/explore-2015-11-07/"), Is.True);
            Assert.That(_provider.CanServeUrl("https://flic.kr/p/AcQbTP"), Is.True);
        }

        [Test]
        public void Can_get_result()
        {
            var result = _provider.Embed("https://www.flickr.com/photos/oneredballoon/22450013589/in/explore-2015-11-07/") as IPhotoEmbeddedResult;
            Assert.That(result, Is.Not.Null);
        }

        [SetUp]
        public void Setup()
        {
            _provider = EmbedlurContext.Resolver.ResolveByName("Flickr");
        }
    }
}
