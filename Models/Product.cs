using MongoDB.Bson;

namespace minimal_products_api.Models;

public class Product : IEntity
{
    public ObjectId? _id { get; init; }
}