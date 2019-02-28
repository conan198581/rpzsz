using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service.Entities;

namespace ZSZ.Service.EntityConfig
{
    public class RegionEntityConfig:EntityTypeConfiguration<RegionEntity>
    {
        public RegionEntityConfig()
        {
            this.ToTable("T_Regions");
            this.Property(x => x.Name).IsRequired().HasMaxLength(250);
            this.HasRequired(x => x.City).WithMany().HasForeignKey(x => x.CityId).WillCascadeOnDelete(false);
        }
    }
}
