using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ZSZ.Service.Entities;

namespace ZSZ.Service.EntityConfig
{
    public class HouseAppointmentEntityConfig:EntityTypeConfiguration<HouseAppointmentEntity>
    {
        public HouseAppointmentEntityConfig()
        {
            this.ToTable("T_HouseAppointments");
            this.Property(x => x.Name).IsRequired().HasMaxLength(50);
            this.Property(x => x.PhoneNum).IsRequired().HasMaxLength(50);
            this.Property(x => x.Status).IsRequired().HasMaxLength(50);
            this.HasOptional(x => x.AppointUser).WithMany().HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
            this.HasOptional(x => x.AdminUser).WithMany().HasForeignKey(x => x.FollowAdminUserId).WillCascadeOnDelete(false);
        }
    }
}
