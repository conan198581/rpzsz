namespace ZSZ.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201902271458_adduserrolepermission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Roles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Permissions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_AdminUserRoles",
                c => new
                    {
                        AdminUserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.AdminUserId, t.RoleId })
                .ForeignKey("dbo.T_Roles", t => t.AdminUserId, cascadeDelete: true)
                .ForeignKey("dbo.T_AdminUsers", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.AdminUserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.T_RolePermissions",
                c => new
                    {
                        RoleId = c.Long(nullable: false),
                        PermissionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.PermissionId })
                .ForeignKey("dbo.T_Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.T_Permissions", t => t.PermissionId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.PermissionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_RolePermissions", "PermissionId", "dbo.T_Permissions");
            DropForeignKey("dbo.T_RolePermissions", "RoleId", "dbo.T_Roles");
            DropForeignKey("dbo.T_AdminUserRoles", "RoleId", "dbo.T_AdminUsers");
            DropForeignKey("dbo.T_AdminUserRoles", "AdminUserId", "dbo.T_Roles");
            DropIndex("dbo.T_RolePermissions", new[] { "PermissionId" });
            DropIndex("dbo.T_RolePermissions", new[] { "RoleId" });
            DropIndex("dbo.T_AdminUserRoles", new[] { "RoleId" });
            DropIndex("dbo.T_AdminUserRoles", new[] { "AdminUserId" });
            DropTable("dbo.T_RolePermissions");
            DropTable("dbo.T_AdminUserRoles");
            DropTable("dbo.T_Permissions");
            DropTable("dbo.T_Roles");
        }
    }
}
