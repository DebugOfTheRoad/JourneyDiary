﻿using AutoMapper;
using JourneyDiary.Model.DataModel.Customers;
using JourneyDiary.Model.ViewModel;

namespace JourneyDiary.Web
{
	public class AutoMapperMapping
	{
        public  static IMapper Mapper;

        public static void RegisterMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerModel, Customer>();
                cfg.CreateMap<Customer, CustomerModel>();
            });

            Mapper = config.CreateMapper();
        }
	}
}