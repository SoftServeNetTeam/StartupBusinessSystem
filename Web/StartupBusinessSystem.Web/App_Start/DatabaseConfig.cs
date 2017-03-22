namespace StartupBusinessSystem.Web
{
    using System.Data.Entity;

    using StartupBusinessSystem.Data;
    using StartupBusinessSystem.Data.Migrations;

    public static class DatabaseConfig
    {
        public static void RegisterMigrations()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StartupBusinessDbContext, Configuration>());
        }
    }
}