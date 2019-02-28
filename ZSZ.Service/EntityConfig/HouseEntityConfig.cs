using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ZSZ.Service.Entities;

namespace ZSZ.Service.EntityConfig
{
    public class HouseEntityConfig:EntityTypeConfiguration<HouseEntity>
    {
        public HouseEntityConfig()
        {
            this.ToTable("T_Houses");
            this.Property(x => x.Address).IsRequired().HasMaxLength(200);
            this.Property(x => x.Direction).IsRequired().HasMaxLength(10);
            this.Property(x => x.OwnerName).IsRequired().HasMaxLength(20);
            this.Property(x => x.OwnerPhoneNum).IsRequired().HasMaxLength(20);
            this.HasRequired(x => x.CommunityEntity).WithMany().HasForeignKey(x => x.CommunityId).WillCascadeOnDelete(false);
            this.HasRequired(x => x.RoomTypeEntity).WithMany().HasForeignKey(x => x.RoomTypeId).WillCascadeOnDelete(false);
            this.HasRequired(x => x.StatusEntity).WithMany().HasForeignKey(x => x.StatusId).WillCascadeOnDelete(false);
            this.HasRequired(x => x.DecorateStatusEntity).WithMany().HasForeignKey(x => x.DecorateStatusId).WillCascadeOnDelete(false);
            this.HasRequired(x => x.HouseTypeEntity).WithMany().HasForeignKey(x => x.TypeId).WillCascadeOnDelete(false);
        }
    }
}
