﻿using Microsoft.AspNet.Identity;
using StartupBusinessSystem.Data.Repositories;
using StartupBusinessSystem.Models;
using StartupBusinessSystem.Web.ViewModels.Participations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StartupBusinessSystem.Web.Controllers
{
    [Authorize]
    public class ParticipationsController : Controller
    {
        private IRepository<Campaign> campaigns;
        private IRepository<User> users;
        private IRepository<Participation> participations;

        public ParticipationsController(IRepository<Participation> participations, IRepository<Campaign> campaigns, IRepository<User> users)
        {
            this.participations = participations;
            this.campaigns = campaigns;
            this.users = users; 
        }

        [HttpGet]
        public ActionResult AddToCampaign(int id)
        {

            var campaign = this.campaigns.GetById(id);

            if (campaign == null)
            {
                return this.HttpNotFound();
            }

            var participationViewModel = new CreateParticipationViewModel
            {
                Name = campaign.Name,
                CurrentShares = campaign.CurrentShares,
                TotalShares = campaign.TotalShares,
                PricePerShare = campaign.PricePerShare                
            };

            return this.View(participationViewModel);
        }

        [HttpPost]
        public ActionResult AddToCampaign(int id, CreateParticipationViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var campaign = this.campaigns.GetById(id);

            if (campaign == null)
            {
                return this.HttpNotFound();
            }

            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.users.GetById(currentUserId);

            if (currentUser == null)
            {
                return this.HttpNotFound();
            }

            var participation = new Participation
            {
                MakeOffer = model.MakeOffer,
                Campaign = campaign,
                User = currentUser,                
            };

            this.participations.Add(participation);
            this.participations.SaveChanges();

            return this.RedirectToAction("Index", "Home");

        }

    }
}