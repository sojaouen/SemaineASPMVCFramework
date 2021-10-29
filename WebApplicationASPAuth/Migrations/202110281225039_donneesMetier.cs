namespace WebApplicationASPAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class donneesMetier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        Photo = c.String(),
                        CategorieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategorieID, cascadeDelete: true)
                .Index(t => t.CategorieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produits", "CategorieID", "dbo.Categories");
            DropIndex("dbo.Produits", new[] { "CategorieID" });
            DropTable("dbo.Produits");
            DropTable("dbo.Categories");
        }
    }
}
