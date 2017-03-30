namespace StartupBusinessSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}