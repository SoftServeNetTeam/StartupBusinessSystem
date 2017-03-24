namespace StartupBusinessSystem.Web.ViewModels.Campaigns
{
    using System;

    using StartupBusinessSystem.Models;

    public class CampaignViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int GoalPrice { get; set; }

        public CampaignStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UsernameAsString { get; set; }
    }
}