namespace StartupBusinessSystem.Web
{
    using System.Web.Mvc;

    public static class ViewEnginesConfig
    {
        public static void RegisterViewEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}