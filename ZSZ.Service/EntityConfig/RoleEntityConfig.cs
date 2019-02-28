using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ZSZ.Service.Entities;

namespace ZSZ.Service.EntityConfig
{
    public class RoleEntityConfig:EntityTypeConfiguration<RoleEntity>
    {
        public RoleEntityConfig()
        {
            this.ToTable("T_Roles");
            this.Property(x => x.Name).IsRequired().HasMaxLength(250);
            this.HasMany(x => x.AdminUserEntities).WithMany(x => x.RoleEntities).Map(x =>
            {
                x.ToTable("T_AdminUserRoles").MapLeftKey("AdminUserId").MapRightKey("RoleId");
            });
            this.HasMany(x => x.PermissionEntities).WithMany(x => x.RoleEntities).Map(x =>
            {
                x.ToTable("T_RolePermissions").MapLeftKey("RoleId").MapRightKey("PermissionId");
            });
        }
    }
}
