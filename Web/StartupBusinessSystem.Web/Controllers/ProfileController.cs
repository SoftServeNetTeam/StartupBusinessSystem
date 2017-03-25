namespace StartupBusinessSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using StartupBusinessSystem.Data.Repositories;
    using StartupBusinessSystem.Models;
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
        public ActionResult MyParticipations(int page = 1, int size = 1)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.users.GetById(currentUserId);

            var participationsCount = currentUser.Participations.Count;

            var allPagesCount = (int)Math.Ceiling(participationsCount / (decimal)size);


            //var participations = this.participations
            //    .All()
            //    .Where(p => p.User.Id == currentUserId)
            //    .OrderBy(p => p.SharesOwned)
            //    .Skip((page - 1) * size)
            //    .Take(size)
            //    .Select(p => new ParticipationDetailsViewModel
            //    {
            //        Campaign = p.Campaign,
            //        User = p.User,
            //        SharesOwned = p.SharesOwned,
            //        MakeOffer = p.MakeOffer,
            //        Status = p.Status
            //    })
            //.ToList();

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

            if (this.participations == null)
            {
                return this.HttpNotFound();
            }

            return this.View(participationsViewModel);
        }
    }
}