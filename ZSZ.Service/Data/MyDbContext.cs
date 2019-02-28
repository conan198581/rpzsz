﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service.Entities;

namespace ZSZ.Service.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext():base("name=connStr")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<SettingsEntity> SettingsEntities { get; set; }
        public DbSet<CityEntity> CityEntities { get; set; }
        public DbSet<RegionEntity> RegionEntities { get; set; }
        public DbSet<CommunityEntity> CommunityEntities { get; set; }
        public DbSet<AdminUserEntity> AdminUserEntities { get; set; }
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<PermissionEntity> PermissionEntities { get; set; }


    }
}
