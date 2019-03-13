using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZSZ.AdminWeb.Filters
{
    public class JsonNetResult:JsonResult
    {
        public JsonSerializerSettings Settings { get; set; }

        public JsonNetResult()
        {
            Settings = new JsonSerializerSettings() {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatString = "yyyy-MM-dd HH:mm:ss",
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "get", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("json 不允许 get 请求");
            }
            HttpResponseBase response = context.HttpContext.Response;            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;            if (this.ContentEncoding != null)                response.ContentEncoding = this.ContentEncoding;            if (this.Data == null)                return;            var scriptSerializer = JsonSerializer.Create(this.Settings);            scriptSerializer.Serialize(response.Output, this.Data);
        }
    }
}