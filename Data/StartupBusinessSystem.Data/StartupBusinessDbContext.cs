namespace StartupBusinessSystem.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using StartupBusinessSystem.Models;

    public class StartupBusinessDbContext : IdentityDbContext<User>
    {
        public StartupBusinessDbContext()
            : base("StartupBusiness")
        {
        }

        public virtual IDbSet<Campaign> Campaigns { get; set; }

        public virtual IDbSet<Participation> Participations { get; set; }

        public static StartupBusinessDbContext Create()
        {
            return new StartupBusinessDbContext();
        }
    }
}
