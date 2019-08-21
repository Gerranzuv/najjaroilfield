namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contex1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.String(),
                        EmployeeProspectId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Creator = c.String(),
                        Modifier = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.EmployeeProspects", t => t.EmployeeProspectId, cascadeDelete: true)
                .Index(t => t.EmployeeProspectId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        EmployeeProspectId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Creator = c.String(),
                        Modifier = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.EmployeeProspects", t => t.EmployeeProspectId, cascadeDelete: true)
                .Index(t => t.EmployeeProspectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "EmployeeProspectId", "dbo.EmployeeProspects");
            DropForeignKey("dbo.Languages", "EmployeeProspectId", "dbo.EmployeeProspects");
            DropIndex("dbo.Skills", new[] { "EmployeeProspectId" });
            DropIndex("dbo.Languages", new[] { "EmployeeProspectId" });
            DropTable("dbo.Skills");
            DropTable("dbo.Languages");
        }
    }
}
