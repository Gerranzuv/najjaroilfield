namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manageitem1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PicklistItems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        PicklistId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Creator = c.String(),
                        Modifier = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Picklists", t => t.PicklistId, cascadeDelete: true)
                .Index(t => t.PicklistId);
            
            CreateTable(
                "dbo.Picklists",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Creator = c.String(),
                        Modifier = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PicklistItems", "PicklistId", "dbo.Picklists");
            DropIndex("dbo.PicklistItems", new[] { "PicklistId" });
            DropTable("dbo.Picklists");
            DropTable("dbo.PicklistItems");
        }
    }
}
