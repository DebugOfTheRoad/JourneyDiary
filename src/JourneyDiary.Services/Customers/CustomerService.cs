using System;
using System.Collections.Generic;
using JourneyDiary.Data.Customers;
using JourneyDiary.Model.DO;

namespace JourneyDiary.Services.Customers
{
    public class CustomerService:ICustomerService
    {

        public int AddCustomer(CustomerDO customerDo)
        {
            if (customerDo == null)
                throw new ArgumentNullException("customerDo");

           return  CustomerData.Add(customerDo);
        }

        public List<CustomerDO> GetAllCustomers()
        {
            return CustomerData.GetAllCustomer();
        }
    }
}
