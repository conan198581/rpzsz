﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.CommonMVC
{
    public class AjaxResult<T>
    {
        public string Status { get; set; }
        public string Msg { get; set; }
        public T Data { get; set; }
    }
}
