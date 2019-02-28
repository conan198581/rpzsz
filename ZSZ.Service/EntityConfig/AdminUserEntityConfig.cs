using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ZSZ.Service.Entities;

namespace ZSZ.Service.EntityConfig
{
    class AdminUserEntityConfig:EntityTypeConfiguration<AdminUserEntity>
    {
        public AdminUserEntityConfig()
        {
            this.ToTable("T_AdminUsers");
            this.Property(x => x.Name).IsRequired().HasMaxLength(50);
            this.Property(x => x.PhoneNum).IsRequired().HasMaxLength(50);
            this.Property(x => x.PasswordSolt).IsRequired().HasMaxLength(50);
            this.Property(x => x.PasswordHash).IsRequired().HasMaxLength(250);
            this.Property(x => x.Emai).IsRequired().HasMaxLength(50);
            this.HasOptional(x => x.CityEntity).WithMany().HasForeignKey(x => x.CityId);
            
        }
    }
}
