namespace StartupBusinessSystem.Web.ViewModels.Profile
{
    using StartupBusinessSystem.Models;

    public class ParticipationDetailsViewModel
    {
        public ParticipationStatus Status { get; set; }

        public int OfferedPrice { get; set; }

        public int SharesOwned { get; set; }

        public virtual User User { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}