using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using JourneyDiary.Core.DataModel;
using JourneyDiary.Services.Customers;
using JourneyDiary.Web.Extension;
using JourneyDiary.Web.Models;

namespace JourneyDiary.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var customers=_customerService.GetAllCustomers();
            var customerModels= _mapper.Map<List<CustomerModel>>(customers);
            return View(customerModels);
        }

        [HttpPost]
        public ActionResult Register(CustomerModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                //这个地方可以返回错误页面
                return Content(ModelState.ToErrorMessage());
            }

            var customer = _mapper.Map<Customer>(customerModel);
            customer.CreateTime = DateTime.Now;
            _customerService.AddCustomer(customer);
            return Content("ok");
        }
    }
}
