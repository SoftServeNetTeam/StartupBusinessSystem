namespace StartupBusinessSystem.Web.ViewModels.Profile
{
    using System.ComponentModel.DataAnnotations;

    public class EditProfileViewModel
    {
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description")]
        public string CompanyDescription { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Address")]
        public string CompanyAddress { get; set; }

        [Display(Name = "Phone")]
        public string CompanyPhone { get; set; }
    }
}