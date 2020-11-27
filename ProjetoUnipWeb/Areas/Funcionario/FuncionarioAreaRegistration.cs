using System.Web.Mvc;

namespace ProjetoUnipWeb.Areas.Funcionario
{
    public class FuncionarioAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Funcionario";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Funcionario_default",
                "Funcionario/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}