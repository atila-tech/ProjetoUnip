using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoUnipWeb.Areas.Medico
{
    public class MedicoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Medico";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Medico_default",
                "Medico/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}