namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeVacation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeesVacations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        LastModificationDate = c.DateTime(nullable: false),
                        startDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeesVacations");
        }
    }
}
