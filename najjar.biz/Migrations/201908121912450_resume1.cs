namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resume1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeProspects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        From = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        To = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Position = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        EmployeeProspectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.WorkExperiences",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        AddressInArabic = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        EmployeeImage = c.String(),
                        Nationality = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Sex = c.String(nullable: false),
                        BirthPlace = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkExperiences");
            DropTable("dbo.EmployeeProspects");
        }
    }
}
