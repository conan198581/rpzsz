using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service.Entities;

namespace ZSZ.Service.EntityConfig
{
    public class IdNamesEntityConfig:EntityTypeConfiguration<IdNamesEntity>
    {
        public IdNamesEntityConfig()
        {
            this.ToTable("T_IdNames");
            this.Property(x => x.Name).HasMaxLength(250).IsRequired();
            this.Property(x => x.TypeName).HasMaxLength(50).IsRequired();
        }
    }
}
