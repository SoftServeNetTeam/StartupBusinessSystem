namespace StartupBusinessSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using StartupBusinessSystem.Data.Repositories;
    using StartupBusinessSystem.Models;
    using StartupBusinessSystem.Web.ViewModels.Campaigns;
    using StartupBusinessSystem.Web.ViewModels.Profile;

    [Authorize]
    public class ProfileController : Controller
    {
        private IRepository<Campaign> campaigns;
        private IRepository<Participation> participations;
        private IRepository<User> users;

        public ProfileController(IRepository<User> users, IRepository<Campaign> campaigns,
            IRepository<Participation> participations)
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
                return this.HttpNotFound();
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

            return this.View(companyProfileViewModel);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.users.GetById(userId);

            var viewModel = new EditProfileViewModel
            {
                CompanyName = user.UserName,
                CompanyDescription = user.Description,
                CompanyPhone = user.PhoneNumber,
                CompanyAddress = user.Address
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.users.GetById(userId);

            user.UserName = model.CompanyName;
            user.Description = model.CompanyDescription;
            user.PhoneNumber = model.CompanyPhone;
            user.Address = model.CompanyAddress;

            this.users.Update(user);
            this.users.SaveChanges();

            return RedirectToAction("CompanyProfile");
        }

        [HttpGet]
        public ActionResult MyParticipations(int page = 1, int size = 5)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.users.GetById(currentUserId);

            var participationsCount = currentUser.Participations.Count;
            var allPagesCount = (int)Math.Ceiling(participationsCount / (decimal)size);

            var userParticipations = currentUser.Participations
                .OrderBy(p => p.SharesOwned)
                .Skip((page - 1) * size)
                .Take(size)
                .Select(p => new ParticipationDetailsViewModel
                {
                    Campaign = p.Campaign,
                    User = p.User,
                    SharesOwned = p.SharesOwned,
                    MakeOffer = p.MakeOffer,
                    Status = p.Status
                })
                .ToList();

            var participationsViewModel = new ListParticipationsViewModel
            {
                CurrentPage = page,
                PagesCount = allPagesCount,
                PageSize = size,
                ParticipationsList = userParticipations
            };

            return this.View(participationsViewModel);
        }

        [HttpGet]
        public ActionResult MyStartups(int page = 1, int size = 5)
        {
            var currentUserId = this.User.Identity.GetUserId();

            if (currentUserId == null)
            {
                return this.HttpNotFound();
            }

            var currentUser = this.users.GetById(currentUserId);

            var campaignsCount = currentUser.Campaigns.Count;        
            var allPagesCount = (int)Math.Ceiling(campaignsCount / (decimal)size);

            var userCampaigns = currentUser
                .Campaigns
                .OrderBy(c => c.CreatedOn)
                .Skip((page - 1) * size)
                .Take(size)
                .Select(c => new CampaignViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    GoalPrice = c.GoalPrice,
                    CreatedOn = c.CreatedOn,
                    Status = c.Status
                })
                .ToList();

            var campaignsViewModel = new ListCampaignsViewModel
            {
                CurrentPage = page,
                PagesCount = allPagesCount,
                PageSize = size,
                CampaignsList = userCampaigns
            };

            return this.View(campaignsViewModel);
        }
    }
}