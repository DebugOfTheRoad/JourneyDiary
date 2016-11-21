using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JourneyDiary.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("main");
        }

        /// <summary>
        /// 全局异常捕获测试
        /// </summary>
        public ActionResult TestException()
        {
            throw  new Exception("test ception");
        }

    }
}
