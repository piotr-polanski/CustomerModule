using System.Web.Http;

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
