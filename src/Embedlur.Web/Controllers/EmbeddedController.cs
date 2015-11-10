﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Embedlur.Web.Controllers
{
    public class EmbeddedController : Controller
    {
        private readonly IProviderResolver _providerResolver;

        public EmbeddedController(IProviderResolver providerResolver)
        {
            _providerResolver = providerResolver;
        }

        public EmbeddedController()
        {
            _providerResolver = new ProviderResolver(new ProviderDiscovery(new RequestService()));
        }

        public ActionResult Embed(string url = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                // for testing
                // twitter
                //url = "https://twitter.com/SHAQ/status/661263631045238784";
                // youtube
                url = "https://www.youtube.com/watch?v=xjS6SftYQaQ";
            }
            //url = "https://www.youtube.com/watch?v=xjS6SftYQaQ";

            var provider = _providerResolver.Resolve(url);
            
            if(provider == null)
                throw new Exception("The url has no provider that can handle it.");

            ViewBag.ProviderName = provider.Name;

            var result = provider.Embed(url);

            if(result == null)
                throw new Exception("Couldn't get the embedded result from the provider.");

            return View("Providers/" + result.ProviderName, result);
        }
    }
}