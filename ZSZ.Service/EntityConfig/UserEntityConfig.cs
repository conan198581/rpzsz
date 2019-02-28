using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ZSZ.Service.Entities;

namespace ZSZ.Service.EntityConfig
{
    public class UserEntityConfig:EntityTypeConfiguration<User>
    {
        public UserEntityConfig()
        {
            this.ToTable("T_Users");
            this.Property(x => x.PhoneNum).IsRequired().HasMaxLength(20);
            this.Property(x => x.PasswordHash).IsRequired().HasMaxLength(100);
            this.Property(x => x.PasswordSalt).IsRequired().HasMaxLength(100);
            this.HasOptional(x => x.CityEntity).WithMany().HasForeignKey(x => x.CityId).WillCascadeOnDelete(false);
        }
    }
}
