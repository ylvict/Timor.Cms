﻿using MongoDB.Bson;
using Timor.Cms.Domains.Entities;
using Timor.Cms.PersistModels.MongoDb.Entities;

namespace Timor.Cms.Repository.MongoDb.Collections
{
    public interface IMongoCollectionProvider<TEntity> where TEntity : MongoEntityBase
    {
        IMongoCollectionAdapter<TEntity> GetCollection();
    }
}