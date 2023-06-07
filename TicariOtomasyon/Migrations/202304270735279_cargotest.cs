namespace TicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cargotest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDatails",
                c => new
                    {
                        CargoDatailId = c.Int(nullable: false, identity: true),
                        explanation_ = c.String(maxLength: 300, unicode: false),
                        trackingcode = c.String(maxLength: 10, unicode: false),
                        employee = c.String(maxLength: 20, unicode: false),
                        buyer = c.String(maxLength: 20, unicode: false),
                        date_ = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoDatailId);
            
            CreateTable(
                "dbo.CargoTrackings",
                c => new
                    {
                        CargoTrakingId = c.Int(nullable: false, identity: true),
                        CargoTrakingCode = c.String(maxLength: 10, unicode: false),
                        explanation_ = c.String(maxLength: 100, unicode: false),
                        date_ = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoTrakingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoTrackings");
            DropTable("dbo.CargoDatails");
        }
    }
}
