using Limestock.Domain.Models;
using Limestock.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Limestock.EFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : modelID
    {
        private readonly LimestockDbContextFactory _contextFactory;

        public GenericDataService(LimestockDbContextFactory contextFactory)
        {
            //bikin instansiasi baru dbcontext
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using LimestockDbContext context = _contextFactory.CreateDbContext();
            
            context.Database.EnsureCreated();
            EntityEntry<T> recordBaru = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return recordBaru.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            using LimestockDbContext context = _contextFactory.CreateDbContext();

            /*
             * Method untuk menghapus record berdasar id yang di passing
             */
            context.Database.EnsureCreated();
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<T> Get(int id)
        {
            using LimestockDbContext context = _contextFactory.CreateDbContext();

            /*
             * Method untuk me-return data record dalam tabel
             * berdasarkan id
             */
            context.Database.EnsureCreated();
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.id == id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using LimestockDbContext context = _contextFactory.CreateDbContext();

            /* 
             * Fungsi untuk me-return semua data record tabel dalam
             * bentuk IEnumerable
             */
            context.Database.EnsureCreated();
            IEnumerable<T> entities = await context.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> Update(int id, T entity)
        {
            /*
             * Method untuk mengupdate seluruh properti domain di tabel
             * untuk bisa dipake harus bikin helper method.
             */
            using LimestockDbContext context = _contextFactory.CreateDbContext();
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
