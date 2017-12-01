namespace HelloWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyWorlds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.MyEntities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MyEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.MyWorlds");
        }
    }
}
