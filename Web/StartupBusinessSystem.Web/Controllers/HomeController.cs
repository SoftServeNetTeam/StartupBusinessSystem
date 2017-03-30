namespace StartupBusinessSystem.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            return this.View();
        }
    }
}