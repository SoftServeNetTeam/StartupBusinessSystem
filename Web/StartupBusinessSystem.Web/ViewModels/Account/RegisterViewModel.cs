namespace StartupBusinessSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [MaxLength(15)]
        [MinLength(9)]
        [Display(Name = "ID Number")]
        public string CompanyIdentityNumber { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Company Address")]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [MaxLength(250)]
        [Display(Name = "Company Description")]
        public string Description { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}