namespace OnlineRealEstate.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PropertyValues", "PropertyFeatureId", "dbo.PropertyFeatures");
            DropIndex("dbo.PropertyValues", new[] { "PropertyFeatureId" });
            AddColumn("dbo.PropertyFeatures", "PropertyValues_ValueId", c => c.Int());
            CreateIndex("dbo.PropertyFeatures", "PropertyValues_ValueId");
            AddForeignKey("dbo.PropertyFeatures", "PropertyValues_ValueId", "dbo.PropertyValues", "ValueId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyFeatures", "PropertyValues_ValueId", "dbo.PropertyValues");
            DropIndex("dbo.PropertyFeatures", new[] { "PropertyValues_ValueId" });
            DropColumn("dbo.PropertyFeatures", "PropertyValues_ValueId");
            CreateIndex("dbo.PropertyValues", "PropertyFeatureId");
            AddForeignKey("dbo.PropertyValues", "PropertyFeatureId", "dbo.PropertyFeatures", "PropertyFeatureId", cascadeDelete: true);
        }
    }
}
