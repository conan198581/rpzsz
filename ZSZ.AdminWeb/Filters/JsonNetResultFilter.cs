﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZSZ.AdminWeb.Filters
{
    public class JsonNetResultFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var result = filterContext.Result;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}