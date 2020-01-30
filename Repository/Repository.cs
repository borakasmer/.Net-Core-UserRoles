using System;

namespace Repository
{
    using DB.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;


    namespace Repository
    {
        public class Repository<T> : IRepository<T> where T : class
        {
            private readonly NorthwindContext _context;
            private DbSet<T> _entities;

            public Repository(NorthwindContext context)
            {
                _context = context;
                _entities = context.Set<T>();
            }

            public virtual T GetById(object id)
            {
                return Entities.Find(id);
            }

            public void Insert(T entity)
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                _context.Entry(entity).Property("UsedTime").CurrentValue = DateTime.Now;
                //---------------

                _entities.Add(entity);
                _context.SaveChanges();
            }

            public virtual void Insert(IEnumerable<T> entities)
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    Entities.Add(entity);

                _context.SaveChanges();
            }

            public void Update(T entity)
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                _context.SaveChanges();
            }

            public virtual void Update(IEnumerable<T> entities)
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                _context.SaveChanges();
            }

            public void Delete(T entity)
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                Entities.Remove(entity);
                _context.SaveChanges();
            }

            public virtual void Delete(IEnumerable<T> entities)
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    Entities.Remove(entity);
                _context.SaveChanges();
            }

            public IEnumerable<T> GetSql(string sql)
            {
                return Entities.FromSqlRaw(sql);
            }
            public virtual IQueryable<T> Table => Entities;

            public virtual IQueryable<T> TableNoTracking => Entities.AsNoTracking();

            protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());

        }
    }
}
