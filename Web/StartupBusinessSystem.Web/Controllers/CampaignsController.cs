namespace StartupBusinessSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using StartupBusinessSystem.Data.Repositories;
    using StartupBusinessSystem.Models;
    using StartupBusinessSystem.Web.ViewModels.Campaigns;
    using StartupBusinessSystem.Web.ViewModels.Participations;

    [Authorize]
    public class CampaignsController : Controller
    {
        private IRepository<Campaign> campaigns;
        private IRepository<Participation> participations;
        private IRepository<User> users;

        public CampaignsController(IRepository<Campaign> campaigns, IRepository<User> users,
            IRepository<Participation> participations)
        {
            this.campaigns = campaigns;
            this.participations = participations;
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

            var campaignsViewModel = new ListCampaignsViewModel
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
        [ValidateAntiForgeryToken]
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
                TotalShares = model.Shares,
                AvailableShares = model.Shares
            };

            this.campaigns.Add(campaign);
            this.campaigns.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var campaign = this.campaigns.GetById(id);

            if (campaign == null)
            {
                return this.HttpNotFound();
            }

            var campaignsViewModel = new DetailsCampaignViewModel
            {
                Id = campaign.Id,
                Name = campaign.Name,
                Status = campaign.Status,
                Description = campaign.Description,
                CreatedOn = campaign.CreatedOn,
                GoalPrice = campaign.GoalPrice,
                Shares = campaign.TotalShares,
                UnitPerShare = campaign.PricePerShare,
                CompanyDescription = campaign.User.Description,
                CompanyName = campaign.User.UserName,
                CompanyAddress = campaign.User.Address,
                CompanyEmail = campaign.User.Email,
                CompanyPhone = campaign.User.PhoneNumber,
                CampaignAvailableShares = campaign.AvailableShares,
                CampaignTotalShares = campaign.TotalShares,
                Owner = campaign.User
            };

            return this.View(campaignsViewModel);
        }

        [HttpGet]
        public ActionResult CompanyProfile(string id)
        {
            var user = this.users.GetById(id);

            if (user == null)
            {
                return this.HttpNotFound();
            }

            var companyProfileViewModel = new RequestProfileViewModel
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
        public ActionResult Manage(int id)
        {
            var userId = this.User.Identity.GetUserId();
            var currentUser = this.users.GetById(userId);

            var campaign = this.campaigns.GetById(id);

            if (campaign == null)
            {
                return this.HttpNotFound();
            }

            if (!currentUser.Campaigns.Contains(campaign))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var campaignParticipations = campaign
                .Participations
                .OrderBy(p => p.CreatedOn)
                .Where(p => p.Status == ParticipationStatus.Pending)
                .Select(p => new AcceptParticipationViewModel
                {
                    Id = p.Id,
                    CreatedOn = p.CreatedOn,
                    Status = p.Status,
                    OfferedPrice = p.OfferedPrice,
                    CompanyName = p.User.UserName,
                    OfferedShares = p.OfferedPrice,
                    ParticipationCreatorId = p.User.Id
                })
                .ToList();

            var campaignsManageViewModel = new ManageCampaignViewModel
            {
                AllPendingParticipations = campaignParticipations,
                isAccepted = true
            };

            return this.View(campaignsManageViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(int id, ManageCampaignViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Manage", new { id = id });
            }

            var userId = this.User.Identity.GetUserId();
            var currentUser = this.users.GetById(userId);

            var campaign = this.campaigns.GetById(id);

            if (!currentUser.Campaigns.Contains(campaign))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var participation = campaign.Participations.FirstOrDefault(p => p.Id == model.ParticipationId);

            if (participation == null)
            {
                return this.HttpNotFound();
            }

            if (model.isAccepted == true)
            {
                if (model.SharesGivenToUser > participation.OfferedPrice)
                {
                    return this.PartialView("Error");
                }

                participation.Status = ParticipationStatus.Accepted;
                participation.SharesOwned = model.SharesGivenToUser;

                this.participations.Update(participation);
                this.participations.SaveChanges();

                campaign.AvailableShares -= model.SharesGivenToUser;

                if (campaign.AvailableShares < 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (campaign.AvailableShares == 0)
                {
                    campaign.Status = CampaignStatus.Finished;
                }

                this.campaigns.Update(campaign);
                this.campaigns.SaveChanges();
            }
            else
            {
                participation.Status = ParticipationStatus.Refused;

                this.participations.Update(participation);
                this.participations.SaveChanges();
            }

            return this.RedirectToAction("Manage", new { id = id });
        }
    }
}