using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using MealServWebApi.App_Start;

namespace MealServWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Initialise Bootstrapper
            Bootstrapper.Initialise();

            //Define Formatters
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            // settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
          //  var appXmlType = formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
          //  formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            //Add CORS Handler
            GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());
            GlobalConfiguration.Configuration.EnsureInitialized(); 
        }
    }
}
