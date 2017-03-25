namespace StartupBusinessSystem.Web.ViewModels.Profile
{
    using System;
    using StartupBusinessSystem.Models;

    public class ParticipationDetailsViewModel
    {
        public ParticipationStatus Status { get; set; }

        public int MakeOffer { get; set; }

        public int SharesOwned { get; set; }

        public virtual User User { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}