using Limestock.Domain.Models;
using Limestock.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
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
            using(LimestockDbContext context = _contextFactory.CreateDbContext())
            {
                //cek database udah ready
                context.Database.EnsureCreated();

                //method logic
                EntityEntry<T> recordBaru = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return recordBaru.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (LimestockDbContext context = _contextFactory.CreateDbContext())
            {
                //cek database udah ready
                context.Database.EnsureCreated();

                //method logic
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (LimestockDbContext context = _contextFactory.CreateDbContext())
            {
                //cek database udah ready
                context.Database.EnsureCreated();

                //method logic
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.id == id);

                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (LimestockDbContext context = _contextFactory.CreateDbContext())
            {
                //cek database udah ready
                context.Database.EnsureCreated();

                //method logic
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();

                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (LimestockDbContext context = _contextFactory.CreateDbContext())
            {
                //cek database udah ready
                context.Database.EnsureCreated();

                //method logic
                entity.id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                
                return entity;
            }
        }
    }
}
