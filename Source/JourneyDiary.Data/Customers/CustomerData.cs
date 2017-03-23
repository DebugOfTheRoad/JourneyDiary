using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using JourneyDiary.Core.DataModel;

namespace JourneyDiary.Data.Customers
{
    public class CustomerData:ICustomerData
    {
        public  int AddCustomer(Customer customer)
        {
            const string sql = "insert into Customers(Phone,Password,Nick,Age,CreateTime,IsEnabled) " +
                                   "Values (@Phone,@Password,@Nick,@Age,@CreateTime,@IsEnabled);SELECT CAST(SCOPE_IDENTITY() AS INT)";

            using (var dbConnection = ConnectionFactory.CreateConnection())
            {
                dbConnection.Open();
                var id = dbConnection.Query<int>(sql, customer).Single();
                return id;
            }
        }

        public  List<Customer> GetAllCustomer()
        {
            const string sql = "select * from Customers";
            using (IDbConnection dbConnection = ConnectionFactory.CreateConnection())
            {
                dbConnection.Open();
                return dbConnection.Query<Customer>(sql).ToList();
            }
        }



        public  Customer GetCustomer(string phone)
        {
            using (IDbConnection dbConnection = ConnectionFactory.CreateConnection())
            {
                const string sql = "select * from Customers where Phone = @phone and IsDisabled=0";
                return dbConnection.Query<Customer>(sql, new { phone }).FirstOrDefault();
            }
        }

        public  int UpdatePhone(string phone, int userId)
        {
            const string sql = @"update Customers set Phone = @phone where UserId = @UserId;";
            using (IDbConnection dbConnection = ConnectionFactory.CreateConnection())
            {
                dbConnection.Open();
                return dbConnection.Execute(sql, new { phone, userId });
            }
        }
        
    }
}
