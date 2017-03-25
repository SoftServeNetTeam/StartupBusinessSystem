namespace StartupBusinessSystem.Web.ViewModels.Profile
{
    using System.Collections.Generic;

    public class ListParticipationsViewModel
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<ParticipationDetailsViewModel> ParticipationsList { get; set; }
    }
}