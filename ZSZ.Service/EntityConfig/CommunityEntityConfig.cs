using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ZSZ.Service.Entities;

namespace ZSZ.Service.EntityConfig
{
    public class CommunityEntityConfig:EntityTypeConfiguration<CommunityEntity>
    {
        public CommunityEntityConfig()
        {
            this.ToTable("T_Communities");
            this.Property(x => x.Name).HasMaxLength(250).IsRequired();
            this.Property(x => x.Location).IsRequired();
            this.Property(x => x.Traffic).IsRequired();
            this.HasRequired(x => x.Region).WithMany().HasForeignKey(x => x.RegionId);
        }
    }
}
