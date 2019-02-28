using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ZSZ.Service.Entities;

namespace ZSZ.Service.EntityConfig
{
    class PermissionEntityConfig:EntityTypeConfiguration<PermissionEntity>
    {
        public PermissionEntityConfig()
        {
            this.ToTable("T_Permissions");
            this.Property(x => x.Name).IsRequired().HasMaxLength(250);
            this.Property(x => x.Description).IsRequired();
        }
        
    }
}
