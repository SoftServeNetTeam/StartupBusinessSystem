namespace StartupBusinessSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using StartupBusinessSystem.Data.Repositories;
    using StartupBusinessSystem.Models;

    public class HomeController : Controller
    {
        private IRepository<Campaign> campaigns;
        private IRepository<Participation> partisipants;
        private IRepository<User> users;

        public HomeController(IRepository<Campaign> campaigns, IRepository<Participation> partisipants, IRepository<User> users)
        {
            this.campaigns = campaigns;
            this.users = users;
            this.partisipants = partisipants;
        }

        public ActionResult Index()
        {            
            var collection = this.users.All().ToList();
            

            return View(collection);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}