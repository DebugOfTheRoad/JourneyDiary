using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using StackExchange.Profiling;

namespace JourneyDiary.Data
{
    public class ConnectionFactory
    {
        public static IDbConnection CreateConnection()
        {
            DbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["JourneyDiary"].ConnectionString);
            if (bool.Parse(ConfigurationManager.AppSettings["OpenMiniProfiler"]))
            {
                dbConnection = new StackExchange.Profiling.Data.ProfiledDbConnection(dbConnection, MiniProfiler.Current);
            }

            return dbConnection;
        }
    }
}
