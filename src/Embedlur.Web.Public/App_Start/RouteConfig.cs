﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Embedlur.Web.Public
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "OEmbed",
                url: "oembed",
                defaults: new {controller = "OEmbed", action = "Query"});

            routes.MapRoute(
                name: "Image",
                url: "image",
                defaults: new { controller = "Embedded", action = "Image" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Embedded", action = "Embed" }
            );
        }
    }
}
