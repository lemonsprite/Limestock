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
            _contextFactory = contextFactory;
        }



        /// <summary>
        /// Metod definisi untuk membuat record baru berdasar entity yang dipassing
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Entity baru dalam tabel.</returns>
        public async Task<T> Create(T entity)
        {
            using LimestockDbContext context = _contextFactory.CreateDbContext();
            
            EntityEntry<T> recordBaru = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return recordBaru.Entity;
        }


        /// <summary>
        /// Method untuk menghapus record berdasar id yang di passing
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean bahwa record telah dihapus</returns>
        public async Task<bool> Delete(int id)
        {
            using LimestockDbContext context = _contextFactory.CreateDbContext();

            context.Database.EnsureCreated();
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }
        

        /// <summary>
        /// Metod untuk mengambil dalata dalam tabel.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Record dari tabel.</returns>
        public async Task<T> Get(int id)
        {
            using LimestockDbContext context = _contextFactory.CreateDbContext();

            context.Database.EnsureCreated();
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            return entity;
        }


        /// <summary>
        /// Mengambil semua record
        /// </summary>
        /// <returns>Record table dalam bentuk IEnumerable</returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            using LimestockDbContext context = _contextFactory.CreateDbContext();

            context.Database.EnsureCreated();
            IEnumerable<T> entities = await context.Set<T>().ToListAsync();
            return entities;
        }


        /// <summary>
        /// Update data tabel dari entity yang dipassing
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> Update(int id, T entity)
        {
            using LimestockDbContext context = _contextFactory.CreateDbContext();

            context.Database.EnsureCreated();
            entity.Id = id;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            
            return entity;
        }
    }
}
