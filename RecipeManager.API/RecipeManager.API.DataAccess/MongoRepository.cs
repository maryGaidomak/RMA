using MongoDB.Driver;
using RecipeManager.API.DataAccess.Contracts;

namespace RecipeManager.API.DataAccess
{
	public class MongoRepository<T>: IMongoRepository<T>
	{
		FilterDefinitionBuilder<T> _filterBuilder;
		private readonly IMongoCollection<T> _collection;

		public MongoRepository(IMongoDatabase database, 
			string collectionName)
		{
			_collection = database.GetCollection<T>(collectionName);
			_filterBuilder = new FilterDefinitionBuilder<T>();
		}

		public async Task<IEnumerable<T>> GetAllAsync(ProjectionDefinition<T> project, int limit)
		{
			return await _collection.Find(_ => true).Project<T>(project).Limit(limit).ToListAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync(FilterDefinition<T> filter, ProjectionDefinition<T> projection, int limit)
		{
			var query = _collection.Find(filter).Limit(limit);
			if (projection != null)
			{
				query = query.Project<T>(projection);
			}
			return await query.ToListAsync();
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			var filter = Builders<T>.Filter.Eq("_id", id);
			return await _collection.Find(filter).FirstOrDefaultAsync();
		}

		public async Task<T> CreateAsync(T entity)
		{
			await _collection.InsertOneAsync(entity);
			return entity;
		}

		public async Task UpdateAsync(Guid id, T entity)
		{
			var filter = Builders<T>.Filter.Eq("_id", id);
			await _collection.ReplaceOneAsync(filter, entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			var filter = Builders<T>.Filter.Eq("_id", id);
			await _collection.DeleteOneAsync(filter);
		}
	}
}
