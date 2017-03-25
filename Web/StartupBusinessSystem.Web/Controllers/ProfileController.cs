namespace StartupBusinessSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using StartupBusinessSystem.Data.Repositories;
    using StartupBusinessSystem.Models;
    using StartupBusinessSystem.Web.ViewModels.Profile;


    [Authorize]
    public class ProfileController : Controller
    {
        private IRepository<User> users;
        private IRepository<Campaign> campaigns;
        private IRepository<Participation> participations;

        public ProfileController(IRepository<User> users, IRepository<Campaign> campaigns, IRepository<Participation> participations)
        {
            this.users = users;
            this.campaigns = campaigns;
            this.participations = participations;
        }

        [HttpGet]
        public ActionResult CompanyProfile()
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.users.GetById(userId);

            if (user == null)
            {
                return HttpNotFound();
            }

            var companyProfileViewModel = new CompanyProfileViewModel
            {
                CompanyName = user.UserName,
                CompanyIDNumber = user.CompanyIdentityNumber,
                CompanyDescription = user.Description,
                CompanyAddress = user.Address,
                CompanyEmail = user.Email,
                CompanyPhone = user.PhoneNumber
            };
            return View(companyProfileViewModel);
        }

        [HttpGet]
        public ActionResult ParticipationDetails()
        {
            var currentUserId = this.User.Identity.GetUserId();

            var participations = this.participations
                .All()
                .Where(p =>p.User.Id == currentUserId)
                .OrderBy(p => p.SharesOwned)
                .Select(p => new ParticipationDetailsViewModel
                {
                    Campaign = p.Campaign,
                    User = p.User,
                    SharesOwned = p.SharesOwned,
                    MakeOffer = p.MakeOffer,
                    Status = p.Status
                })
            .ToList();

            if (participations == null)
            {
                return HttpNotFound();
            }

            return this.View(participations);
        }
    }
}