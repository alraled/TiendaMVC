﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TiendaMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute

                (

                    name: "DetalleProducto",
                    url: "producto/{nombre}",
                    defaults: new
                    {
                        controller = "Producto",
                        action = "Detalle",
                        nombre = UrlParameter.Optional
                    }



                );

            routes.MapRoute
                (
                
                name: "Default",
                
                url: "{controller}/{action}/{id}",
                
                defaults: new { controller = "Producto",
                          action = "Index",
                          id = UrlParameter.Optional }
                );
        }
    }
}
