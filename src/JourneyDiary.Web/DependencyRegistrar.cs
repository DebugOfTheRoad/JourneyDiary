using System;
using System.Linq;
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
            var services = AppDomain.CurrentDomain.GetAssemblies().
                Where(a => a.FullName.Contains("JourneyDiary.Services")).ToArray();
            builder.RegisterAssemblyTypes(services)
           .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();

            //数据访问层
            var dataAccess = AppDomain.CurrentDomain.GetAssemblies().
              Where(a => a.FullName.Contains("JourneyDiary.Data")).ToArray();
            builder.RegisterAssemblyTypes(dataAccess)
           .Where(t => t.Name.EndsWith("Data"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();

            //公共处理
            var managers = AppDomain.CurrentDomain.GetAssemblies().
              Where(a => a.FullName.Contains("JourneyDiary.Common")).ToArray();
            builder.RegisterAssemblyTypes(managers)
           .Where(t => t.Name.EndsWith("Manager"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}