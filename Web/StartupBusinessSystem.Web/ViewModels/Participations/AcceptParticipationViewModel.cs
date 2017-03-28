namespace StartupBusinessSystem.Web.ViewModels.Participations
{
    using System;

    using StartupBusinessSystem.Models;

    public class AcceptParticipationViewModel
    {
        public string CompanyName { get; set; }

        public int OfferedShares { get; set; }

        public int Id { get; set; }

        public ParticipationStatus Status { get; set; }

        public int MakeOffer { get; set; }

        public DateTime CreatedOn { get; set; }

        public User ParticipationCreator { get; set; }
    }
}