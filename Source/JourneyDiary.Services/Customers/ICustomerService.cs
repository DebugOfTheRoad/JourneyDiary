using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using JourneyDiary.Model.DataModel;

namespace JourneyDiary.Services.Customers
{
    public interface ICustomerService
    {
        int AddCustomer(Customer customer);

        List<Customer> GetAllCustomers();
    }
}
