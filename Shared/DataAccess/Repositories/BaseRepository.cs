using minimal_products_api.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace minimal_products_api.DataAccess.Repositories;

public abstract class BaseRepository<T>
    where T : IEntity
{
    public abstract required string CollectionName { get; set; }

    private readonly IMongoCollection<T> _repository;

    public BaseRepository(IMongoDatabase db)
    {
        _repository = db.GetCollection<T>(CollectionName);
    }

    public async Task<T> GetByIdAsync(ObjectId id)
    {
        var cursor = await _repository.FindAsync(x => x._id == id, new FindOptions<T>
        {
            Limit = 1
        });

        return await cursor.FirstAsync();
    }

    public async Task<IEnumerable<T>> GetTopAsync(int top)
    {
        var cursor = await _repository.FindAsync(null, options: new FindOptions<T>
        {
            Limit = top
        });

        return await cursor.ToListAsync();
    }

    public Task Save(T entity)
    {
        if (entity._id is null)
        {
            return _repository.InsertOneAsync(entity);
        }
        
        return _repository.ReplaceOneAsync(x => x._id == entity._id, entity);
    }
}
