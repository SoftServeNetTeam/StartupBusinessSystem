namespace StartupBusinessSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}