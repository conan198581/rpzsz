using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service.Entities
{
    public class RoleEntity:BaseEntity
    {
        public string Name { get; set; }
        public virtual List<AdminUserEntity> AdminUserEntities { get; set; }
        public virtual List<PermissionEntity> PermissionEntities { get; set; }
    }
}
