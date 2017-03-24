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
        private IRepository<User> users;

        public ProfileController(IRepository<User> users)
        {            
            this.users = users;           
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

    }
}