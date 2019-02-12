using System.Configuration;
namespace AdoNetFirma2019.DAL {
    public class MyConnection {
        public static string GetConnectionString() {
            var connString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            return connString;
        }
    }
}