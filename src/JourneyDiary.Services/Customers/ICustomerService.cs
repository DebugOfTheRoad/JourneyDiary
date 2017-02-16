using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using JourneyDiary.Model.DO;

namespace JourneyDiary.Services.Customers
{
    public interface ICustomerService
    {
        int AddCustomer(CustomerDO customerDo);

        List<CustomerDO> GetAllCustomers();
    }
}
