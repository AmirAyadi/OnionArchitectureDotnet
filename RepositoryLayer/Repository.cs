using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _applicationContext;
        private DbSet<T> entities;


        #region Constructor
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationContext = applicationDbContext;
            entities = _applicationContext.Set<T>();
        }
        # endregion

        public void Delete(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _applicationContext.SaveChanges();
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _applicationContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _applicationContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _applicationContext.SaveChanges();
        }
    }
}
