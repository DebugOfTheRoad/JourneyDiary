using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;
using JourneyDiary.Common;
using JourneyDiary.Common.Helper;
using log4net.Config;
using StackExchange.Profiling;
using StackExchange.Profiling.Mvc;

namespace JourneyDiary.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MvcHandler.DisableMvcResponseHeader = true;

            //log4net
            XmlConfigurator.Configure();  
            //fluent validation
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider());
            //automapper
            AutoMapperMapping.RegisterMapping();
            //IOC
            DependencyRegistrar.Register();
            // miniprofiler
            GlobalFilters.Filters.Add(new ProfilingActionFilter());
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            if (Request.IsLocal)
            {
                return;
            }

            var exception = Server.GetLastError();

            //不处理404异常
            var httpException = exception as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404)
            {
                return;
            }

            if (exception != null)
            {
                LogHelper.Current.Error("Application_Error", exception);
                LogHelper.Current.Error(exception.StackTrace.ToString());
                //导向错误页面
                Response.Clear();
                Response.StatusCode = 500;
                Response.Write("系统出现了异常,请重试");
                Response.End();
            }
        }

        protected void Application_BeginRequest()
        {
            if(bool.Parse(ConfigurationManager.AppSettings["OpenMiniProfiler"]))
            {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest()
        {
            if (bool.Parse(ConfigurationManager.AppSettings["OpenMiniProfiler"]))
            {
                MiniProfiler.Stop(discardResults: false);
            }
            HttpContext.Current.Response.Headers.Remove("Server");
        }
    }
}