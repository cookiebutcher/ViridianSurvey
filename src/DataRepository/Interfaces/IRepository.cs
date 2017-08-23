using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ViridianCode.ViridianSurvey.DataModel;

namespace ViridianCode.ViridianSurvey.DataRepository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);
    }
}