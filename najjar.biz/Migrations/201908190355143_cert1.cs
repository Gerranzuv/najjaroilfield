namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cert1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Certifications", "Name", c => c.String());
            AddColumn("dbo.Certifications", "CertificationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Certifications", "University", c => c.String());
            AddColumn("dbo.Certifications", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Certifications", "Location");
            DropColumn("dbo.Certifications", "University");
            DropColumn("dbo.Certifications", "CertificationDate");
            DropColumn("dbo.Certifications", "Name");
        }
    }
}
