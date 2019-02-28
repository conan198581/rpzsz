using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ZSZ.Service.Entities;

namespace ZSZ.Service.EntityConfig
{
    class AttachmentEntityConfig:EntityTypeConfiguration<AttachmentEntity>
    {
        public AttachmentEntityConfig()
        {
            this.ToTable("T_Attachments");
            this.Property(x => x.Name).HasMaxLength(50).IsRequired();
            this.Property(x => x.IconName).HasMaxLength(50).IsRequired();
            this.HasMany(x => x.HouseEntities).WithMany(x => x.AttachmentEntities).Map(x => {
                x.ToTable("T_HouseAttachments").MapLeftKey("HouseId").MapRightKey("AttachmentId");
            });
        }
    }
}
