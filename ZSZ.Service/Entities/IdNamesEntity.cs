﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service.Entities
{
    /// <summary>
    /// 字典表
    /// </summary>
    public class IdNamesEntity:BaseEntity
    {
        public string TypeName { get; set; }
        public string Name { get; set; }
    }
}
