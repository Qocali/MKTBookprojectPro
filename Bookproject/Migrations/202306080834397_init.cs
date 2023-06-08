namespace Bookproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleCode = c.String(),
                        Date = c.DateTime(nullable: false),
                        StoreId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.BookId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookStores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.BookStores", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.BookStores", "BookId", "dbo.Books");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Sales", "BookId", "dbo.Books");
            DropIndex("dbo.BookStores", new[] { "BookId" });
            DropIndex("dbo.BookStores", new[] { "StoreId" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Sales", new[] { "BookId" });
            DropIndex("dbo.Sales", new[] { "StoreId" });
            DropTable("dbo.BookStores");
            DropTable("dbo.Stores");
            DropTable("dbo.Customers");
            DropTable("dbo.Sales");
            DropTable("dbo.Books");
        }
    }
}
