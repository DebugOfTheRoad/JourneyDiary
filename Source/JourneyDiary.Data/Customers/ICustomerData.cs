using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JourneyDiary.Core.DataModel;


namespace JourneyDiary.Data.Customers
{
    public interface ICustomerData
    {
        int AddCustomer(Customer customer);

        List<Customer> GetAllCustomer();

        Customer GetCustomer(string phone);

        int UpdatePhone(string phone, int userId);
    }
}
