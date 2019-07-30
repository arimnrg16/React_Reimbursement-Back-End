using Data.Abstractions;
using Data.Entities;
using ExtCore.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.EntityFramework.Sqlite
{
    public abstract class Repository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity> where TEntity : Entity
    {
        public virtual IEnumerable<TEntity> All(int page = 0, int size = 25)
        {
            return this.dbSet.OrderByDescending(e => e.Created).Skip(page * size).Take(size);
        }

        public virtual void Create(TEntity entity, string username)
        {
            entity.Created = DateTime.Now;
            entity.CreatedBy = username;

            this.dbSet.Add(entity);
        }

        public virtual void Delete(int id, string username)
        {
            this.Delete(this.WithKey(id), username);
        }

        public virtual void Delete(TEntity entity, string username)
        {
            if (entity is ISoftDelete)
            {
                var recordToDelete = entity as ISoftDelete;
                recordToDelete.Deleted = DateTime.Now;
                recordToDelete.DeleteBy = username;
                recordToDelete.IsDeleted = true;

                this.storageContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                this.dbSet.Remove(entity);
            }
        }

        public virtual void Edit(TEntity entity, string username)
        {
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            this.storageContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual TEntity WithKey(int id)
        {
            return this.dbSet.FirstOrDefault(e => e.Id == id);
        }
    }
}
