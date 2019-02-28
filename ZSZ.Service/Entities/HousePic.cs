using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service.Entities
{
    public class HousePic:BaseEntity
    {
        public string Url { get; set; }
        public string ThumbUrl { get; set; }
        public long HouseId { get; set; }
        public virtual HouseEntity HouseEntity { get; set; }
    }
}
