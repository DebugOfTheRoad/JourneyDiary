using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JourneyDiary.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        #region 全局异常捕获

        /// <summary>
        /// 全局异常捕获测试
        /// </summary>
        public ActionResult TestException()
        {
            throw new Exception("test ception");
        }

        #endregion

        #region 使用分布视图加载分页

        public ActionResult News()
        {
            return View();
        }

        public ActionResult RenderNews(int pageIndex = 1, int pageSize = 10)
        {

            return PartialView();
        }

        #endregion



        
    }
}
