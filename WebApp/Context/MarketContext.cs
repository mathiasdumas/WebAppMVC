using System;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Context
{
	public class MarketContext : DbContext
	{
        public MarketContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()

        }
    }
}


