namespace StartupBusinessSystem.Web.ViewModels.Participations
{
    public class CreateParticipationViewModel
    {
        public string Name { get; set; }

        public int MakeOffer { get; set; }

        public int CurrentShares { get; set; } 

        public int TotalShares { get; set; }

        public int PricePerShare { get; set; }
    }
}