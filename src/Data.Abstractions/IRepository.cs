using Data.Entities;
using ExtCore.Data.Abstractions;
using System;
using System.Collections.Generic;

namespace Data.Abstractions
{
    public interface IRepository<TEntity> : IRepository where TEntity : Entity
    {
        TEntity WithKey(int id);

        IEnumerable<TEntity> All(int page = 0, int size = 25);

        void Create(TEntity entity, string username);

        void Edit(TEntity entity, string username);

        void Delete(int id, string username);

        void Delete(TEntity entity, string username);
    }
}
