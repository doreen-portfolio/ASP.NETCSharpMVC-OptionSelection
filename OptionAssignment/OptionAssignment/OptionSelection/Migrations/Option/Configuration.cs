namespace OptionSelection.Migrations.Option
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OptionClassLibrary.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<OptionSelection.DataContext.OptionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Option";
        }

        protected override void Seed(OptionSelection.DataContext.OptionContext context)
        {
            context.Terms.AddOrUpdate(
                new Term { TermCode = 201410, Description = "Winter 2014", IsActive = false },
                new Term { TermCode = 201420, Description = "Spring/Summer 2014", IsActive = true },
                new Term { TermCode = 201430, Description = "Fall 2014", IsActive = false },
                new Term { TermCode = 201510, Description = "Winter 2015", IsActive = false },
                new Term { TermCode = 201520, Description = "Spring/Summer 2015", IsActive = false }
            );

            context.Options.AddOrUpdate(
                new Option { Title = "Data Communications", IsActive = true },
                new Option { Title = "Client Server", IsActive = true },
                new Option { Title = "Digital Processing", IsActive = true },
                new Option { Title = "Information Systems", IsActive = true },
                new Option { Title = "Database", IsActive = false }
            );

            context.Choices.AddOrUpdate(
                new Choice
                {
                    ChoiceId = 1,
                    StudentNumber = "A00111111",
                    FirstName = "Alice",
                    LastName = "Andrews",
                    TermCode = 201410,
                    FirstChoice = "Data Communications",
                    SecondChoice = "Client Server",
                    ThirdChoice = "Digital Processing",
                    FourthChoice = "Information Systems",
                    CreateDate = DateTime.Now
                }
            );
            context.Choices.AddOrUpdate(
                new Choice
                {
                    ChoiceId = 2,
                    StudentNumber = "A00222222",
                    FirstName = "Bob",
                    LastName = "Brenner",
                    TermCode = 201410,
                    FirstChoice = "Information Systems",
                    SecondChoice = "Database",
                    ThirdChoice = "Client Server",
                    FourthChoice = "Data Communications",
                    CreateDate = DateTime.Now
                }
            );
            context.Choices.AddOrUpdate(
                new Choice
                {
                    ChoiceId = 3,
                    StudentNumber = "A00333333",
                    FirstName = "Chris",
                    LastName = "Conner",
                    TermCode = 201420,
                    FirstChoice = "Digital Processing",
                    SecondChoice = "Data Communications",
                    ThirdChoice = "Client Server",
                    FourthChoice = "Information Systems",
                    CreateDate = DateTime.Now
                }
            );
            context.Choices.AddOrUpdate(
                new Choice
                {
                    ChoiceId = 4,
                    StudentNumber = "A00444444",
                    FirstName = "Donna",
                    LastName = "Draper",
                    TermCode = 201430,
                    FirstChoice = "Database",
                    SecondChoice = "Data Communications",
                    ThirdChoice = "Digital Processing",
                    FourthChoice = "Information Systems",
                    CreateDate = DateTime.Now
                }
            );
            context.Choices.AddOrUpdate(
                new Choice
                {
                    ChoiceId = 5,
                    StudentNumber = "A00555555",
                    FirstName = "Eric",
                    LastName = "Etter",
                    TermCode = 201510,
                    FirstChoice = "Client Server",
                    SecondChoice = "Information Systems",
                    ThirdChoice = "Database",
                    FourthChoice = "Data Communications",
                    CreateDate = DateTime.Now
                }
            );
            context.Choices.AddOrUpdate(
                new Choice
                {
                    ChoiceId = 6,
                    StudentNumber = "A00666666",
                    FirstName = "Fred",
                    LastName = "Fitz",
                    TermCode = 201520,
                    FirstChoice = "Database",
                    SecondChoice = "Information Systems",
                    ThirdChoice = "Client Server",
                    FourthChoice = "Digital Processing",
                    CreateDate = DateTime.Now
                }
            );
        }
    }
}
