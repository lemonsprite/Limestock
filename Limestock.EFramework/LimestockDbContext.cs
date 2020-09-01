using Limestock.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Limestock.EFramework
{
    public class LimestockDbContext : DbContext
    {
        //konstruktor untuk kelas dbContext
        public LimestockDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders);


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Konsumen> Konsumen { get; set; }
        public DbSet<Produk> Produk { get; set; }
    }
}
