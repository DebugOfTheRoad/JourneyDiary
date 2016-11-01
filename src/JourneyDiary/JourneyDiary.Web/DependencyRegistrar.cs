using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using JourneyDiary.Services.Customers;

namespace JourneyDiary.Web
{
    public class DependencyRegistrar
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            //automapper
            builder.RegisterInstance(AutoMapperMapping.Mapper).As<IMapper>();

            //mvc控制器
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterFilterProvider();


            //业务逻辑
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}