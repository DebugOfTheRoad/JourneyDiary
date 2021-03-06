﻿using System;
using System.Collections.Generic;
using JourneyDiary.Core.DataModel;
using JourneyDiary.Data.Customers;

namespace JourneyDiary.Services.Customers
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerData _customerData;

        public CustomerService(ICustomerData customerData)
        {
            _customerData = customerData;
        }


        public int AddCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

           return _customerData.AddCustomer(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerData.GetAllCustomer();
        }
    }
}
