namespace ZSZ.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addadminuser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_AdminUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        PhoneNum = c.String(nullable: false, maxLength: 50),
                        PasswordSolt = c.String(nullable: false, maxLength: 50),
                        PasswordHash = c.String(nullable: false, maxLength: 250),
                        Emai = c.String(nullable: false, maxLength: 50),
                        CityId = c.Long(),
                        LoginErrorTimes = c.Int(),
                        LastLoginErrorDateTime = c.DateTime(),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Cities", t => t.CityId)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_AdminUsers", "CityId", "dbo.T_Cities");
            DropIndex("dbo.T_AdminUsers", new[] { "CityId" });
            DropTable("dbo.T_AdminUsers");
        }
    }
}
