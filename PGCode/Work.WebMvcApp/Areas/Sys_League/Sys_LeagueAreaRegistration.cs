using System.Web.Mvc;

namespace DotWeb.Areas.Sys_League
{
    public class Sys_LeagueAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Sys_League";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Sys_League_default",
                "Sys_League/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
