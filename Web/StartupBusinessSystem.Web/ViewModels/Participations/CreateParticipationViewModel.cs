namespace StartupBusinessSystem.Web.ViewModels.Participations
{
    using System.ComponentModel.DataAnnotations;

    public class CreateParticipationViewModel
    {
        public string Name { get; set; }

        [Display(Name = "Your Offer:")]
        public int MakeOffer { get; set; }

        public int CurrentShares { get; set; }

        public int TotalShares { get; set; }

        public int PricePerShare { get; set; }

        public string OwnerName { get; set; }
    }
}