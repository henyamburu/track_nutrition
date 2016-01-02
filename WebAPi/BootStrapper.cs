using System.Web.Http;
using WebApi.App_Start;

namespace WebApi
{
    public class BootStrapper
    {
        public static void Init(HttpConfiguration config)
        {
            RouteConfig.Register(config);
            WebApiConfig.Register(config);
        }
    }
}
