namespace StartupBusinessSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Campaign
    {
        private ICollection<Participation> participations;

        public Campaign()
        {
            //this.UnitPerShare = this.GoalPrice / this.Shares;
            this.participations = new HashSet<Participation>();
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int GoalPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int CurrentShares { get; set; }

        [Range(0, int.MaxValue)]
        public int TotalShares { get; set; }

        public CampaignStatus Status { get; set; }

        public DateTime CreatedOn { get; private set; }

        [NotMapped]
        public int PricePerShare
        {
            get { return this.GoalPrice / this.TotalShares; }
        }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Participation> Participations
        {
            get
            {
                return this.participations;
            }
            set
            {
                this.participations = value;
            }
        }
    }
}
