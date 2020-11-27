using System.Web;
using System.Web.Optimization;

namespace ProjetoUnipWeb
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatables-buttons2").Include(
            "~/Scripts/dataTable/jquery.dataTables.min.new.js",
            "~/Scripts/dataTable/dataTables.buttons.min.js",
            "~/Scripts/dataTable/jszip.min.js",
            "~/Scripts/dataTable/pdfmake.min.js",
            "~/Scripts/dataTable/vfs_fonts.js",
            "~/Scripts/dataTable/buttons.html5.min.js",
            "~/Scripts/dataTable/buttons.print.min.js"));
        }
    }
}
