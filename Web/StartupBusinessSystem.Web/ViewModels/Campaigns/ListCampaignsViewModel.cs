namespace StartupBusinessSystem.Web.ViewModels.Campaigns
{
    using System.Collections.Generic;

    public class ListCampaignsViewModel
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public int PageSize { get; set; } 

        public IEnumerable<CampaignViewModel> CampaignsList{ get; set; }
    }
}