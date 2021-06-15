using System.Configuration;
namespace Utils
{
   public static class Configuration
    {
    private static string server = ConfigurationManager.AppSettings.Get("Server");
    private static string dbName = ConfigurationManager.AppSettings.Get("dbName");
    public static string GetConnectionString()
    {
        return string.Concat(
            "Data Source =",
            server, ";",
            "Initial Catalog=",
            dbName,
            ";Integrated Security = true;"
            );
    }

}
}
