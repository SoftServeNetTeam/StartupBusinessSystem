namespace StartupBusinessSystem.Web.ViewModels.Campaigns
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCampaignViewModel
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Goal Price")]
        public int GoalPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int Shares { get; set; }
    }
}