using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Limestock.EFramework
{
    public class LimestockDbContextFactory : IDesignTimeDbContextFactory<LimestockDbContext>
    {
        public LimestockDbContext CreateDbContext(string[] args = null)
        {
            var opsi = new DbContextOptionsBuilder<LimestockDbContext>();
            string lokasi = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LimestockApp.db");
            opsi.UseSqlite($"Filename={lokasi}");
            return new LimestockDbContext(opsi.Options);
        }
    }
}
