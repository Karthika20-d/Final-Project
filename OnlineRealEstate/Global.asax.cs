using OnlineRealEstate.App_Start;
using System.Web.Mvc;
using System.Web.Routing;
using OnlineRealEstate.DAL;

namespace OnlineRealEstate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas(); 
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            MapConfig.RegisterMap();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
