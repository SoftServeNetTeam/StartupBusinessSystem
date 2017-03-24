using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StartupBusinessSystem.Web.Controllers
{
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