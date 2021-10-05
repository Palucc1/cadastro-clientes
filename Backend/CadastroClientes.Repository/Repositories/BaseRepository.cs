using CadastroClientes.Domain.Interfaces;
using CadastroClientes.Repository.Context;
using CadastroClientes.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CadastroClientes.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly DbContextOptions<DataContext> _options;
        public BaseRepository(DbContextOptions<DataContext> options) => _options = options;

        public virtual void Add(T obj)
        {
            using (var ctx = new DataContext(_options))
            {
                ctx.Set<T>().Add(obj);
                ctx.SaveChanges();
            }
        }

        public virtual IList<T> GetAll(string query)
        {
            using(var ctx = new DataContext(_options))
            {
                return ctx.Set<T>().ToList();
            }
        }

        public virtual T GetById(long id)
        {
            using(var ctx = new DataContext(_options))
            {
                return ctx.Set<T>().FirstOrDefault(x => x.Id == id);
            }
        }

        public virtual void Remove(T obj)
        {
            using(var ctx = new DataContext(_options))
            {
                ctx.Set<T>().Remove(obj);
                ctx.SaveChanges();
            }
        }

        public virtual void Update(T obj)
        {
            using (var ctx = new DataContext(_options))
            {
                ctx.Set<T>().Update(obj);
                ctx.SaveChanges();
            }
        }
    }
}
