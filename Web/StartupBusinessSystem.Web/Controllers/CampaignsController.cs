namespace StartupBusinessSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using StartupBusinessSystem.Data.Repositories;
    using StartupBusinessSystem.Models;
    using StartupBusinessSystem.Web.ViewModels.Campaigns;

    [Authorize]
    public class CampaignsController : Controller
    {
        private IRepository<Campaign> campaigns;
        private IRepository<User> users;

        public CampaignsController(IRepository<Campaign> campaigns, IRepository<User> users)
        {
            this.campaigns = campaigns;
            this.users = users;
        }

        [HttpGet]
        public ActionResult All(int page = 1, int size = 5)
        {
            var campaignsCount = this.campaigns.All().Count();

            var allPagesCount = (int)Math.Ceiling(campaignsCount / (decimal)size);

            var campaigns = this.campaigns
                .All()
                .OrderBy(c => c.CreatedOn)
                .Skip((page - 1) * size)
                .Take(size)
                .Select(c => new CampaignViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    GoalPrice = c.GoalPrice,
                    CreatedOn = c.CreatedOn,
                    UsernameAsString = c.User.UserName,
                    Status = c.Status
                })
                .ToList();

            var campaignsViewModel = new CampaignsListViewModel
            {
                CurrentPage = page,
                PagesCount = allPagesCount,
                PageSize = size,
                CampaignsList = campaigns
            };

            return this.View(campaignsViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(CreateCampaignViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            if (model.GoalPrice % 10 != 0)
            {
                this.ModelState.AddModelError(string.Empty, "Goal Price must be divisible by 10");
                return this.View(model);
            }

            if (model.Shares % 5 != 0)
            {
                this.ModelState.AddModelError(string.Empty, "Shares must be divisible by 5");
                return this.View(model);
            }

            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.users.GetById(currentUserId);

            var campaign = new Campaign
            {
                Name = model.Name,
                User = currentUser,
                Description = model.Description,
                GoalPrice = model.GoalPrice,
                Shares = model.Shares
            };

            this.campaigns.Add(campaign);
            this.campaigns.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }

    }
}