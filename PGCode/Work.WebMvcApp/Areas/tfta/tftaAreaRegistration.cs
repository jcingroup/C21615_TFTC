using System.Web.Mvc;

namespace DotWeb.WebApp.Areas.tfta
{
    public class tftaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "tfta";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
            "tfta_default",
            "tfta",
            new { action = "Index",controller="index", id = UrlParameter.Optional }
            );


            context.MapRoute(
                "tfta_general",
                "tfta/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
