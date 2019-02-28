namespace ZSZ.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Cities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Communities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        RegionId = c.Long(nullable: false),
                        Location = c.String(nullable: false),
                        Traffic = c.String(nullable: false),
                        BuiltYear = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.T_Regions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        CityId = c.Long(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.T_Settings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Value = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Communities", "RegionId", "dbo.T_Regions");
            DropForeignKey("dbo.T_Regions", "CityId", "dbo.T_Cities");
            DropIndex("dbo.T_Regions", new[] { "CityId" });
            DropIndex("dbo.T_Communities", new[] { "RegionId" });
            DropTable("dbo.T_Settings");
            DropTable("dbo.T_Regions");
            DropTable("dbo.T_Communities");
            DropTable("dbo.T_Cities");
        }
    }
}
