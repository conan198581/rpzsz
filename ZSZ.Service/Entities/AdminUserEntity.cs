using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service.Entities
{
    public class AdminUserEntity:BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string PasswordSolt { get; set; }
        public string PasswordHash { get; set; }
        public string Emai { get; set; }
        public long? CityId { get; set; }
        public int? LoginErrorTimes { get; set; }
        public DateTime? LastLoginErrorDateTime { get; set; }
        public virtual CityEntity CityEntity { get; set; }
        public virtual List<RoleEntity> RoleEntities { get; set; }
    }
}
