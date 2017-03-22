using System.Collections.Generic;
using JourneyDiary.Core.DataModel;

namespace JourneyDiary.Services.Customers
{
    public interface ICustomerService
    {
        int AddCustomer(Customer customer);

        List<Customer> GetAllCustomers();
    }
}
