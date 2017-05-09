using System.Web.Http;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Customer.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
			UnityConfig.RegisterComponents();                           
        }
    }
}
