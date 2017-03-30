namespace StartupBusinessSystem.Web.ViewModels.Participations
{
    using System.ComponentModel.DataAnnotations;

    public class CreateParticipationViewModel
    {
        public string Name { get; set; }

        [Display(Name = "Your Offer")]
        public int OfferedPrice { get; set; }

        public int AvailableShares { get; set; }

        public int TotalShares { get; set; }

        public int PricePerShare { get; set; }

        public string OwnerName { get; set; }
    }
}