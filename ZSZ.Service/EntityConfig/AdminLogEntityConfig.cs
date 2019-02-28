using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ZSZ.Service.Entities;

namespace ZSZ.Service.EntityConfig
{
    public class AdminLogEntityConfig:EntityTypeConfiguration<AdminLogEntity>
    {
        public AdminLogEntityConfig()
        {
            this.ToTable("T_AdminLogs");
            this.Property(x => x.Msg).IsRequired();
            this.HasRequired(x => x.AdminUser).WithMany().HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
        }
    }
}
