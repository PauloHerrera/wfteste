using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication3.Model;

namespace WindowsFormsApplication3.Data
{
    public class GenericRepository<T> where T : class
    {
        public TesteEntities db = new TesteEntities();

        public T Add(T entity)
        {
            var added = db.Set<T>().Add(entity);
            db.SaveChanges();

            return added;
        }

        public T Remove(T entity)
        {
            var r = db.Set<T>().Remove(entity);
            db.SaveChanges();

            return r;
        }

        public void Remove(long id)
        {
            var entity = db.Set<T>().Find(id);

            if (entity != null)
            {
                db.Set<T>().Remove(entity);
                db.SaveChanges();
            }
        }

        public void AddOrUpdate(T entity)
        {
            db.Set<T>().AddOrUpdate(entity);
            db.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T Get(object key)
        {
            return db.Set<T>().Find(key);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
