using minimal_products_api.Models;
using MongoDB.Driver;

namespace minimal_products_api.DataAccess.Repositories;

public class ProductsRepository : BaseRepository<Product>
{
    public override required string CollectionName { get; set; } = "Products";

    public ProductsRepository(IMongoDatabase db) : base(db)
    { }
}