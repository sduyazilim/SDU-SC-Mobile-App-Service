using SC.Service.Data.Model;
using System.Linq;
using System.Web.Mvc;

namespace SC.Service.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            EFContext con = new EFContext();
            con.Events.ToList();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}