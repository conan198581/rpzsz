using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ZSZ.Service.Entities;

namespace ZSZ.Service.EntityConfig
{
    public class HousePicConfig:EntityTypeConfiguration<HousePic>
    {
        public HousePicConfig()
        {
            this.ToTable("T_HousePics");
            this.Property(x => x.Url).IsRequired();
            this.Property(x => x.ThumbUrl).IsRequired();
            this.HasRequired(x => x.HouseEntity).WithMany().HasForeignKey(x => x.HouseId).WillCascadeOnDelete(false);
        }
    }
}
