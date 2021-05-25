using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Agend
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            List<Entity.Contact> lstContactExemple = new List<Entity.Contact>();
            for (int i = 1; i < 11; i++)
            {
                lstContactExemple.Add
                (
                    new Entity.Contact
                    {
                        id = i,
                        name = string.Concat("Name", i.ToString()),
                        email = string.Concat("Email", i.ToString())
                    }
                );
            }

            Application["lstExample"] = lstContactExemple;
        }
    }
}