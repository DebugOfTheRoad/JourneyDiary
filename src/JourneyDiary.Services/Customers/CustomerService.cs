using System;
using System.Collections.Generic;
using JourneyDiary.Data.Customers;
using JourneyDiary.Model.DataModel;

namespace JourneyDiary.Services.Customers
{
    public class CustomerService:ICustomerService
    {

        public int AddCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

           return  CustomerData.Add(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return CustomerData.GetAllCustomer();
        }
    }
}
