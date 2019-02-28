using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service.Entities;

namespace ZSZ.Service.EntityConfig
{
    public class SettingsEntityConfig:EntityTypeConfiguration<SettingsEntity>
    {
        public SettingsEntityConfig()
        {
            this.ToTable("T_Settings");
            this.Property(t => t.Name).HasMaxLength(250).IsRequired();
            this.Property(x => x.Value).IsRequired();
        }
    }
}
