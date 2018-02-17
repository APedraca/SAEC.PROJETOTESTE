using System.Web.Mvc;
using SAEC.PROJETOTESTE.MVC.Authorizations;

namespace SAEC.PROJETOTESTE.MVC.Controllers
{
    public class HomeController : BaseController
    {
        [Authorization]
        public ActionResult Index()
        {
            return RedirectToAction("AlunoHorario", "Grafico");
        }
    }
}