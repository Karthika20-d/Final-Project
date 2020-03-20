namespace OnlineRealEstate.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        PropertyId = c.Int(nullable: false, identity: true),
                        PropertyTypeID = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Area = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyId)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyTypeID)
                .Index(t => t.PropertyTypeID);
            
            CreateTable(
                "dbo.PropertyTypes",
                c => new
                    {
                        PropertyTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyTypeID);
            
            CreateTable(
                "dbo.PropertyFeatures",
                c => new
                    {
                        PropertyFeatureId = c.Int(nullable: false, identity: true),
                        PropertyTypeID = c.Int(nullable: false),
                        PropertyFeatureName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyFeatureId)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyTypeID)
                .Index(t => t.PropertyTypeID);
            
            CreateTable(
                "dbo.PropertyValues",
                c => new
                    {
                        ValueId = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        PropertyFeatureId = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ValueId)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.PropertyFeatures", t => t.PropertyFeatureId)
                .Index(t => t.PropertyId)
                .Index(t => t.PropertyFeatureId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                        PhoneNumber = c.Long(nullable: false),
                        Password = c.String(nullable: false, maxLength: 20),
                        Role = c.String(nullable: false, maxLength: 10),
                        Location = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Name)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyValues", "PropertyFeatureId", "dbo.PropertyFeatures");
            DropForeignKey("dbo.PropertyValues", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.PropertyFeatures", "PropertyTypeID", "dbo.PropertyTypes");
            DropForeignKey("dbo.Properties", "PropertyTypeID", "dbo.PropertyTypes");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.PropertyValues", new[] { "PropertyFeatureId" });
            DropIndex("dbo.PropertyValues", new[] { "PropertyId" });
            DropIndex("dbo.PropertyFeatures", new[] { "PropertyTypeID" });
            DropIndex("dbo.Properties", new[] { "PropertyTypeID" });
            DropTable("dbo.Users");
            DropTable("dbo.PropertyValues");
            DropTable("dbo.PropertyFeatures");
            DropTable("dbo.PropertyTypes");
            DropTable("dbo.Properties");
        }
    }
}
