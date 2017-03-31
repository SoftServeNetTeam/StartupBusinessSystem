namespace StartupBusinessSystem.Web.ViewModels.Campaigns
{
    using System.Collections.Generic;

    using Participations;
    using System.ComponentModel.DataAnnotations;

    public class ManageCampaignViewModel
    {
        [Required]
        public int ParticipationId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Offer Back")]
        public int SharesGivenToUser { get; set; }

        [Required]
        public bool IsAccepted { get; set; }

        public IEnumerable<AcceptParticipationViewModel> AllPendingParticipations { get; set; }
    }
}