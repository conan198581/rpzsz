using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZSZ.AdminWeb.Filters
{
    public class AdminWebExceptionFilter : IExceptionFilter
    {
        public static ILog log = LogManager.GetLogger(typeof(AdminWebExceptionFilter));
        public void OnException(ExceptionContext filterContext)
        {
            log.Error("出现未处理的异常", filterContext.Exception);
            
        }
    }
}