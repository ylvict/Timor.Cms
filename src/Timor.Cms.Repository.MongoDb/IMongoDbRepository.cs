using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Timor.Cms.PersistModels.MongoDb.Entities;

namespace Timor.Cms.Repository.MongoDb
{
    public interface IMongoDbRepository<TEntity> where TEntity : MongoEntityBase
    {
        Task<TEntity> GetByIdAsync(ObjectId id);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(ObjectId id);
        Task DeleteAsync(TEntity entity);
        Task DeleteMultipleAsync(IEnumerable<ObjectId> ids);
    }
}