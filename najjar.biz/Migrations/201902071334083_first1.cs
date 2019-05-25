namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false),
                        summary = c.String(nullable: false, maxLength: 250),
                        description = c.String(nullable: false),
                        attachment = c.String(),
                        Date = c.DateTime(nullable: false),
                        example = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        lastModificationDate = c.DateTime(nullable: false),
                        creationDate = c.DateTime(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        BirthPlace = c.String(nullable: false),
                        MaritalStatus = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        FixedNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        AddressInArabic = c.String(nullable: false),
                        militaryService = c.String(nullable: false),
                        Joiningdate = c.DateTime(nullable: false),
                        BasicSalary = c.Double(nullable: false),
                        Trasportation = c.Double(nullable: false),
                        HousingAllowance = c.Double(nullable: false),
                        FoodAllowance = c.Double(nullable: false),
                        FullSalary = c.Double(nullable: false),
                        TypeOfEmployee = c.String(nullable: false),
                        SalaryTrasfereMethod = c.String(nullable: false),
                        SalaryTransfereDestination = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        Manager = c.String(nullable: false),
                        TerminationReason = c.String(),
                        TerminationDate = c.DateTime(nullable: false),
                        EmployeeImage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FileDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        SupportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Supports", t => t.SupportId, cascadeDelete: true)
                .Index(t => t.SupportId);
            
            CreateTable(
                "dbo.Supports",
                c => new
                    {
                        SupportId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Summary = c.String(nullable: false, maxLength: 500),
                        EmpId = c.Int(nullable: false),
                        employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.SupportId)
                .ForeignKey("dbo.Employees", t => t.employee_Id)
                .Index(t => t.employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileDetails", "SupportId", "dbo.Supports");
            DropForeignKey("dbo.Supports", "employee_Id", "dbo.Employees");
            DropIndex("dbo.FileDetails", new[] { "SupportId" });
            DropIndex("dbo.Supports", new[] { "employee_Id" });
            DropTable("dbo.Supports");
            DropTable("dbo.FileDetails");
            DropTable("dbo.Employees");
            DropTable("dbo.Articles");
        }
    }
}
