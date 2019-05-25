namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeRating2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeRatings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        LastModificationDate = c.DateTime(nullable: false),
                        Year = c.String(),
                        Rating = c.String(),
                        Status = c.String(),
                        SalaryBeforeUpdate = c.Double(nullable: false),
                        SalaryAfterUpdate = c.Double(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeRatings");
        }
    }
}
