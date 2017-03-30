namespace StartupBusinessSystem.Web.ViewModels.Participations
{
    using System;

    using StartupBusinessSystem.Models;

    public class AcceptParticipationViewModel
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public int OfferedShares { get; set; }

        public ParticipationStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public int OfferedPrice { get; set; }

        public string ParticipationCreatorId { get; set; }
    }
}