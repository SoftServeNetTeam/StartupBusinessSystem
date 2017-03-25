namespace StartupBusinessSystem.Web.ViewModels.Participations
{
    using System;

    using StartupBusinessSystem.Models;

    public class AcceptParticipationViewModel
    {
        public int Id { get; set; }

        public ParticipationStatus Status { get; set; }

        public int MakeOffer { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}