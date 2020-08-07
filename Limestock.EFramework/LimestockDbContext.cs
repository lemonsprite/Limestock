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

        public DbSet<User> Users { get; set; }
    }
}
