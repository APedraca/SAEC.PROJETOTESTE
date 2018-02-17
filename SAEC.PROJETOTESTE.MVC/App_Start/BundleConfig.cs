using System.Web;
using System.Web.Optimization;

namespace SAEC.PROJETOTESTE.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Site.css"));

            #region Cidade

            bundles.Add(new ScriptBundle("~/bundles/Cidade").Include(
                        "~/Scripts/datatables.min.js",
                        "~/Scripts/Cidade/index.js"));

            bundles.Add(new StyleBundle("~/Content/Cidade").Include(
                        "~/Content/datatables.min.css"));

            #endregion

            #region Aluno

            bundles.Add(new ScriptBundle("~/bundles/Aluno").Include(
                "~/Scripts/datatables.min.js",
                "~/Scripts/Aluno/index.js"));

            bundles.Add(new StyleBundle("~/Content/Aluno").Include(
                "~/Content/datatables.min.css"));

            bundles.Add(new StyleBundle("~/Content/Usuario/Login").Include(
                "~/Content/Usuario/Login.css"));

            #endregion

            #region Grafico

            bundles.Add(new ScriptBundle("~/bundles/Grafico/AlunoHorario").Include(
                "~/Scripts/Grafico/AlunoHorario.js"));

            bundles.Add(new ScriptBundle("~/bundles/Grafico/AlunoDias").Include(
                "~/Scripts/Grafico/AlunoDias.js"));

            bundles.Add(new ScriptBundle("~/bundles/Grafico/AlunoCidade").Include(
                "~/Scripts/Grafico/AlunoCidade.js"));

            #endregion
        }
    }
}
