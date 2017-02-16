using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using JourneyDiary.Model.DO;
using JourneyDiary.Model.VO;
using JourneyDiary.Services.Customers;
using JourneyDiary.Web.Extension;

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
            var customerModels= _mapper.Map<List<CustomerVO>>(customers);
            return View(customerModels);
        }

        [HttpPost]
        public ActionResult Register(CustomerVO customerVo)
        {
            if (!ModelState.IsValid)
            {
                //这个地方可以返回错误页面
                return Content(ModelState.ToErrorMessage());
            }

            var customer = _mapper.Map<CustomerDO>(customerVo);
            customer.CreateTime = DateTime.Now;
            _customerService.AddCustomer(customer);
            return Content("ok");
        }
    }
}
