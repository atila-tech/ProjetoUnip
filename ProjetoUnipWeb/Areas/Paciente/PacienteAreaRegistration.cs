using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoUnipWeb.Areas.Paciente
{
    public class PacienteAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Paciente";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Paciente_default",
                "Paciente/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}