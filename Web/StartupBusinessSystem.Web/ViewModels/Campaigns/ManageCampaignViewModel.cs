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
        [Display(Name = "Offer back:")]
        public int SharesGivenToUser { get; set; }

        [Required]
        public bool isAccepted { get; set; }

        public IEnumerable<AcceptParticipationViewModel> AllPendingParticipations { get; set; }
    }
}