using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

[assembly: OwinStartup(typeof(HTMLUIWinFormsApp.Web.Startup))]

namespace HTMLUIWinFormsApp.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            // If you want to enable ASP.NET Web API:
            // 1) Install Microsoft.AspNet.WebApi.Owin NuGet package. (ex."PM> Install-Package Microsoft.AspNet.WebApi.Owin")
            // 2) Import "System.Web.Http" namespace. (insert "using System.Web.Http;" at head of this file)
            // 3) Uncomment lines below.
            // After this, you can implement API controllers with attribute routing.

            //// Confiure ASP.NET Web API
            //var config = new HttpConfiguration();
            //config.MapHttpAttributeRoutes();
            //app.UseWebApi(config);

            // Configure OWIN Static Files middleware to provide contents from embedded resources.
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings["use:OwinStaticFiles"] != "false")
            {
                var fileSystem = new EmbeddedResourceFileSystem(this.GetType().Assembly, this.GetType().Namespace);

                app.UseDefaultFiles(new DefaultFilesOptions
                {
                    FileSystem = fileSystem,
                    DefaultFileNames = new List<string> { "index.html" }
                });

                app.UseStaticFiles(new StaticFileOptions
                {
                    FileSystem = fileSystem,
                    ServeUnknownFileTypes = true,
                    OnPrepareResponse = context =>
                    {
                        var headers = context.OwinContext.Response.Headers;

                        // If you use AngulaJS at client side, it's recomended about 
                        // appending "Cache-control: no-cache" header in response to avoid "cache tatooing".
                        headers.Add("Cache-control", new[] { "no-cache" });

                        // If you want to determine which content source (embedded resouces via Owin Static Files middleware, 
                        // or local file system via IIS) responded, this custom response header will helps you.
                        headers.Add("X-StaticFile-Hanler", new[] { "OwinStaticFiles" });
                    }
                });
            }
        }
    }
}
