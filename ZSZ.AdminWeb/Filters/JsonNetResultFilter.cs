using System;
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
            var result = filterContext.Result;            var jsonResult = new JsonResult();            var jsonNetResult = new JsonNetResult();            if ((result is JsonResult) && (!(result is JsonNetResult)))            {                jsonResult = (JsonResult)result;                jsonNetResult.ContentEncoding = jsonResult.ContentEncoding;                jsonNetResult.ContentType = jsonResult.ContentType;                jsonNetResult.Data = jsonResult.Data;                jsonNetResult.JsonRequestBehavior = jsonResult.JsonRequestBehavior;                jsonNetResult.MaxJsonLength = jsonResult.MaxJsonLength;                jsonNetResult.RecursionLimit = jsonResult.RecursionLimit;                filterContext.Result = jsonNetResult;            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}