using HotelManagerReponsity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private RoomManagerEntities roomManagerEntities;
        private DbSet<T> dbSet;

        public Repository()
        {
            roomManagerEntities = new RoomManagerEntities();
            dbSet = roomManagerEntities.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            roomManagerEntities.Entry(entity).State = EntityState.Modified;
            Save();
        }
        public void Delete(T entity)
        {
            if(roomManagerEntities.Entry(entity).State==EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            Save();
        }
        public void Delete(object id)
        {
            T entity = dbSet.Find(id);
            Delete(entity);
        }

        public void Save()
        {
            try
            {
                roomManagerEntities.SaveChanges();
                
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        
                    }
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (roomManagerEntities != null)
                {
                    roomManagerEntities.Dispose();
                    roomManagerEntities = null;
                }
            }
        }

        
    }
}
