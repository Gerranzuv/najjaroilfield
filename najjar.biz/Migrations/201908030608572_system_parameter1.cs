namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class system_parameter1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SystemParameters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SystemParameters");
        }
    }
}
