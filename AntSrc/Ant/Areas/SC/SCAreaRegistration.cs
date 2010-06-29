using System.Web.Mvc;

namespace Ant.Areas.SC
{
    public class SCAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SC_default",
                "SC/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
