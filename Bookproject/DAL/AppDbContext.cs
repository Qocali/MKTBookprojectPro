using LookProject.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace LookProject.DAL
{
    public class AppDbContext :DbContext
    {
        public AppDbContext() : base("name=Default")
        {
            
        }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<BookStore> BookStore { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure your entity mappings here (if needed)
            base.OnModelCreating(modelBuilder);
        }

    }
}
