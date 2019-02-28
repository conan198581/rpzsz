using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service.Entities;

namespace ZSZ.Service.EntityConfig
{
    public class CityEntityConfig:EntityTypeConfiguration<CityEntity>
    {
        public CityEntityConfig()
        {
            this.ToTable("T_Cities");
            this.Property(x => x.Name).HasMaxLength(250).IsRequired();
        }
    }
}
