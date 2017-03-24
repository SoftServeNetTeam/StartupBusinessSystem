namespace StartupBusinessSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Participation
    {
        public Participation()
        {
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public ParticipationStatus Status { get; set; }

        public int SharesOwned { get; set; }

        public DateTime CreatedOn { get; private set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int CampaignId { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
