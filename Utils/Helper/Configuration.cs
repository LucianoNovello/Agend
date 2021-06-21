using System.Configuration;
namespace Utils
{
   public static class Configuration
    {
        static readonly string connStr = ConfigurationManager.ConnectionStrings["databaseConnect"].ConnectionString;

        public static string GetConnectionString()

    {
            return connStr;

    }

}
}
