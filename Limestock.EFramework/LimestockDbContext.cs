using Limestock.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Limestock.EFramework
{
    public class LimestockDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string lokasi = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.db");
            optionsBuilder.UseSqlite($"Filename={lokasi}");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
