﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ZSZ.CommonMVC
{
    public class TrimToDBCModelBinder: DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            object value = base.BindModel(controllerContext, bindingContext);
            if (value is string)
            {
                string valuestr = (string)value;
                valuestr = ToDBC(valuestr).Trim();
                return valuestr;
            }
            else
            {
                return value;
            }
        }

        //全角转半角方法
        private static string ToDBC(string input)
    }
}