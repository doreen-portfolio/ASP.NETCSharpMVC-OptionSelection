namespace OptionSelection.Migrations.Option
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        ChoiceId = c.Int(nullable: false, identity: true),
                        StudentNumber = c.String(nullable: false, maxLength: 9),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 40),
                        TermCode = c.Int(nullable: false),
                        FirstChoice = c.String(nullable: false, maxLength: 50),
                        SecondChoice = c.String(nullable: false, maxLength: 50),
                        ThirdChoice = c.String(nullable: false, maxLength: 50),
                        FourthChoice = c.String(nullable: false, maxLength: 50),
                        CreateDate = c.DateTime(nullable: false),
                        Option_Title = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ChoiceId)
                .ForeignKey("dbo.Options", t => t.Option_Title)
                .ForeignKey("dbo.Terms", t => t.TermCode, cascadeDelete: true)
                .Index(t => t.TermCode)
                .Index(t => t.Option_Title);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Title);
            
            CreateTable(
                "dbo.Terms",
                c => new
                    {
                        TermCode = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TermCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Choices", "TermCode", "dbo.Terms");
            DropForeignKey("dbo.Choices", "Option_Title", "dbo.Options");
            DropIndex("dbo.Choices", new[] { "Option_Title" });
            DropIndex("dbo.Choices", new[] { "TermCode" });
            DropTable("dbo.Terms");
            DropTable("dbo.Options");
            DropTable("dbo.Choices");
        }
    }
}
