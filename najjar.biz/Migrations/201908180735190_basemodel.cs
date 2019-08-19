namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basemodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkExperiences", "EmployeeProspectId", "dbo.EmployeeProspects");
            DropIndex("dbo.WorkExperiences", new[] { "EmployeeProspectId" });
            CreateTable(
                "dbo.BaseModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        EmployeeProspect_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.EmployeeProspects", t => t.EmployeeProspect_id)
                .Index(t => t.EmployeeProspect_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BaseModels", "EmployeeProspect_id", "dbo.EmployeeProspects");
            DropIndex("dbo.BaseModels", new[] { "EmployeeProspect_id" });
            DropTable("dbo.BaseModels");
            CreateIndex("dbo.WorkExperiences", "EmployeeProspectId");
            AddForeignKey("dbo.WorkExperiences", "EmployeeProspectId", "dbo.EmployeeProspects", "id", cascadeDelete: true);
        }
    }
}
