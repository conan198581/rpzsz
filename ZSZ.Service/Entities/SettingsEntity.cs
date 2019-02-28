using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service.Entities
{
    public class SettingsEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
