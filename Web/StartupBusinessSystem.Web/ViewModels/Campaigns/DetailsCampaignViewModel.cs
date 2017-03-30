namespace StartupBusinessSystem.Web.ViewModels.Campaigns
{
    using System;
    using StartupBusinessSystem.Models;

    public class DetailsCampaignViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int GoalPrice { get; set; }

        public int Shares { get; set; }

        public int UnitPerShare { get; set; }

        public CampaignStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CompanyName { get; set; }

        public string CompanyDescription { get; set; }

        public string CompanyAddress { get; set; }

        public string CompanyPhone { get; set; }

        public string CompanyEmail { get; set; }

        public int CampaignAvailableShares { get; set; }

        public int CampaignTotalShares { get; set; }

        public User Owner { get; set; }

        public bool IsOwner(string name)
        {
            return this.Owner.UserName.Equals(name);
        }
    }
}