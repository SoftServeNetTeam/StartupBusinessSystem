﻿namespace StartupBusinessSystem.Web.Controllers
{
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
        public ActionResult ParticipationDetails(int id)
        {
            var participations = this.participations.GetById(id);

            if (participations == null)
            {
                return HttpNotFound();
            }

            var participationDetailsViewModel = new ParticipationDetailsViewModel
            {
                Campaign = participations.Campaign,
                Status = participations.Status
            };
            return View(participationDetailsViewModel);
        }
    }
}