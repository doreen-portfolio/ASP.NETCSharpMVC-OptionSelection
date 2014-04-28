using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OptionClassLibrary.Models;

namespace OptionSelection.DataContext
{
    public class OptionContext : DbContext
    {
        public OptionContext() : base("name=DiplomaOptions") { }

        public DbSet<Choice> Choices { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Term> Terms { get; set; }
    }
}