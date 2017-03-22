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
            DbConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["JourneyDiary"].ConnectionString);
            if (bool.Parse(ConfigurationManager.AppSettings["OpenMiniProfiler"]))
            {
                cnn = new StackExchange.Profiling.Data.ProfiledDbConnection(cnn, MiniProfiler.Current);
            }

            cnn.Open();
            return cnn;
        }
    }
}
