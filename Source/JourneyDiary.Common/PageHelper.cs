using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace JuiceZone.Infrastructure.Helper
{
    public static class PageHelper
     {
        public static HtmlString ShowPagination(int currentPage, int pageSize, int totalCount,Dictionary<string,string> parameters )
        {

            string urlParam = JoinParameters(parameters);
            var redirectTo = HttpContext.Current.Request.Url.AbsolutePath;
            pageSize = pageSize == 0 ? 3 : pageSize;
            var totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1); //总页数
            var output = new StringBuilder();
            if (totalPages > 1)
            {
                if (currentPage != 1)
                {//处理首页连接
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex=1&pageSize={1}{2}'>首页</a> ", redirectTo, pageSize,urlParam);
                }
                if (currentPage > 1)
                {//处理上一页的连接
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}{3}'>上一页</a> ", redirectTo, currentPage - 1, pageSize, urlParam);
                }
                else
                {
                     output.Append("<span class='pageLink'>上一页</span>");
                }

                output.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {//一共最多显示10个页码，前面5个，后面5个
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {//当前页处理
                            //output.Append(string.Format("[{0}]", currentPage));
                            output.AppendFormat("<a class='cpb' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a> ", redirectTo, currentPage, pageSize, currentPage);
                        }
                        else
                        {//一般页处理
                            output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}{3}'>{4}</a> ", redirectTo, currentPage + i - currint, pageSize, urlParam,currentPage + i - currint);
                        }
                    }
                    output.Append(" ");
                }
                if (currentPage < totalPages)
                {//处理下一页的链接
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}{3}'>下一页</a> ", redirectTo, currentPage + 1, pageSize, urlParam);
                }
                else
                {
                    //output.Append("<span class='pageLink'>下一页</span>");
                }
                output.Append(" ");
                if (currentPage != totalPages)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}{3}'>末页</a> ", redirectTo, totalPages, pageSize, urlParam);
                }
                output.Append(" ");
            }
            output.AppendFormat("第{0}页 / 共{1}页", currentPage, totalPages);//这个统计加不加都行

            return new HtmlString(output.ToString());
        }

        private static string JoinParameters(Dictionary<string, string> parameters)
        {
            if (parameters == null|| parameters.Keys.Count<=0)
            {
                return "";
            }

            var stringBuilder = new StringBuilder();
            foreach (var key in parameters.Keys)
            {
                stringBuilder.Append(@"&{key}={parameters[key]}");
            }

            return stringBuilder.ToString();
        }


    }
}
