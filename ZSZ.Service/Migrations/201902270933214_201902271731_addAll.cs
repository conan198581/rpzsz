namespace ZSZ.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201902271731_addAll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_AdminLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        Msg = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_AdminUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.T_Attachments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IconName = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Houses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CommunityId = c.Long(nullable: false),
                        RoomTypeId = c.Long(nullable: false),
                        Address = c.String(nullable: false, maxLength: 200),
                        MonthRent = c.Int(nullable: false),
                        StatusId = c.Long(nullable: false),
                        Area = c.Double(nullable: false),
                        DecorateStatusId = c.Long(nullable: false),
                        TotalFloorCount = c.Int(nullable: false),
                        FloorIndex = c.Int(nullable: false),
                        TypeId = c.Long(nullable: false),
                        Direction = c.String(nullable: false, maxLength: 10),
                        LookableDateTime = c.DateTime(nullable: false),
                        CheckInDateTime = c.DateTime(nullable: false),
                        OwnerName = c.String(nullable: false, maxLength: 20),
                        OwnerPhoneNum = c.String(nullable: false, maxLength: 20),
                        Description = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Communities", t => t.CommunityId)
                .ForeignKey("dbo.T_IdNames", t => t.DecorateStatusId)
                .ForeignKey("dbo.T_IdNames", t => t.TypeId)
                .ForeignKey("dbo.T_IdNames", t => t.RoomTypeId)
                .ForeignKey("dbo.T_IdNames", t => t.StatusId)
                .Index(t => t.CommunityId)
                .Index(t => t.RoomTypeId)
                .Index(t => t.StatusId)
                .Index(t => t.DecorateStatusId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.T_IdNames",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 250),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_HouseAppointments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(),
                        Name = c.String(nullable: false, maxLength: 50),
                        PhoneNum = c.String(nullable: false, maxLength: 50),
                        VisitDate = c.DateTime(nullable: false),
                        HouseId = c.Long(nullable: false),
                        Status = c.String(nullable: false, maxLength: 50),
                        FollowAdminUserId = c.Long(),
                        FlowDateTime = c.DateTime(),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_AdminUsers", t => t.FollowAdminUserId)
                .ForeignKey("dbo.T_Users", t => t.UserId)
                .ForeignKey("dbo.T_Houses", t => t.HouseId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.HouseId)
                .Index(t => t.FollowAdminUserId);
            
            CreateTable(
                "dbo.T_Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PhoneNum = c.String(nullable: false, maxLength: 20),
                        PasswordHash = c.String(nullable: false, maxLength: 100),
                        PasswordSalt = c.String(nullable: false, maxLength: 100),
                        LoginErrorTimes = c.Int(nullable: false),
                        LastLoginErrorDateTime = c.DateTime(),
                        CityId = c.Long(),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.T_HousePics",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Url = c.String(nullable: false),
                        ThumbUrl = c.String(nullable: false),
                        HouseId = c.Long(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Houses", t => t.HouseId)
                .Index(t => t.HouseId);
            
            CreateTable(
                "dbo.T_HouseAttachments",
                c => new
                    {
                        HouseId = c.Long(nullable: false),
                        AttachmentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.HouseId, t.AttachmentId })
                .ForeignKey("dbo.T_Attachments", t => t.HouseId, cascadeDelete: true)
                .ForeignKey("dbo.T_Houses", t => t.AttachmentId, cascadeDelete: true)
                .Index(t => t.HouseId)
                .Index(t => t.AttachmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_HousePics", "HouseId", "dbo.T_Houses");
            DropForeignKey("dbo.T_HouseAppointments", "HouseId", "dbo.T_Houses");
            DropForeignKey("dbo.T_HouseAppointments", "UserId", "dbo.T_Users");
            DropForeignKey("dbo.T_Users", "CityId", "dbo.T_Cities");
            DropForeignKey("dbo.T_HouseAppointments", "FollowAdminUserId", "dbo.T_AdminUsers");
            DropForeignKey("dbo.T_HouseAttachments", "AttachmentId", "dbo.T_Houses");
            DropForeignKey("dbo.T_HouseAttachments", "HouseId", "dbo.T_Attachments");
            DropForeignKey("dbo.T_Houses", "StatusId", "dbo.T_IdNames");
            DropForeignKey("dbo.T_Houses", "RoomTypeId", "dbo.T_IdNames");
            DropForeignKey("dbo.T_Houses", "TypeId", "dbo.T_IdNames");
            DropForeignKey("dbo.T_Houses", "DecorateStatusId", "dbo.T_IdNames");
            DropForeignKey("dbo.T_Houses", "CommunityId", "dbo.T_Communities");
            DropForeignKey("dbo.T_AdminLogs", "UserId", "dbo.T_AdminUsers");
            DropIndex("dbo.T_HouseAttachments", new[] { "AttachmentId" });
            DropIndex("dbo.T_HouseAttachments", new[] { "HouseId" });
            DropIndex("dbo.T_HousePics", new[] { "HouseId" });
            DropIndex("dbo.T_Users", new[] { "CityId" });
            DropIndex("dbo.T_HouseAppointments", new[] { "FollowAdminUserId" });
            DropIndex("dbo.T_HouseAppointments", new[] { "HouseId" });
            DropIndex("dbo.T_HouseAppointments", new[] { "UserId" });
            DropIndex("dbo.T_Houses", new[] { "TypeId" });
            DropIndex("dbo.T_Houses", new[] { "DecorateStatusId" });
            DropIndex("dbo.T_Houses", new[] { "StatusId" });
            DropIndex("dbo.T_Houses", new[] { "RoomTypeId" });
            DropIndex("dbo.T_Houses", new[] { "CommunityId" });
            DropIndex("dbo.T_AdminLogs", new[] { "UserId" });
            DropTable("dbo.T_HouseAttachments");
            DropTable("dbo.T_HousePics");
            DropTable("dbo.T_Users");
            DropTable("dbo.T_HouseAppointments");
            DropTable("dbo.T_IdNames");
            DropTable("dbo.T_Houses");
            DropTable("dbo.T_Attachments");
            DropTable("dbo.T_AdminLogs");
        }
    }
}
