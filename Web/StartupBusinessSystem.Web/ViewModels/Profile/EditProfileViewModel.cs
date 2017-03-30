namespace StartupBusinessSystem.Web.ViewModels.Profile
{
    using System.ComponentModel.DataAnnotations;

    public class EditProfileViewModel
    {
        public string CompanyName { get; set; }

        [MaxLength(250)]
        public string CompanyDescription { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyAddress { get; set; }

        public string CompanyPhone { get; set; }
    }
}