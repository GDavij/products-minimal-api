using MongoDB.Bson;

namespace minimal_products_api.Models;

public interface IEntity
{
    ObjectId? _id { get; init; }
}