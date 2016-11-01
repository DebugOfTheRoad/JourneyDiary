using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using JourneyDiary.Model.Customers;

namespace JourneyDiary.Data.Customers
{
    public class CustomerData
    {
        public static int Add(Customer customer)
        {
            using (var dbConnection = ConnectionFactory.CreateConnection())
            {
                const string sql = "insert into Customers(Phone,Password,Nick,Age,CreateTime,IsEnabled) " +
                                   "Values (@Phone,@Password,@Nick,@Age,@CreateTime,@IsEnabled);SELECT CAST(SCOPE_IDENTITY() AS INT)";

                var id = dbConnection.Query<int>(sql, customer).Single();
                return id;
            }
        }

        public static List<Customer> GetAllCustomer()
        {
            using (IDbConnection dbConnection = ConnectionFactory.CreateConnection())
            {
                const string sql = "select * from Customers";
                return dbConnection.Query<Customer>(sql).ToList();
            }
        }



        public static Customer GetCustomer(string phone)
        {
            using (IDbConnection dbConnection = ConnectionFactory.CreateConnection())
            {
                const string sql = "select * from Customers where Phone = @phone and IsDisabled=0";
                return dbConnection.Query<Customer>(sql, new { phone }).FirstOrDefault();
            }
        }

        public static int UpdatePhone(string phone, int userId)
        {
            using (IDbConnection dbConnection = ConnectionFactory.CreateConnection())
            {
                const string sql = @"update Customers set Phone = @phone where UserId = @UserId;";
                return dbConnection.Execute(sql, new { phone, userId });
            }
        }
        
    }
}
