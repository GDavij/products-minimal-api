using MongoDB.Driver;

namespace minimal_products_api.DataAccess;

public static class DataAccessDependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoDbConnection = configuration.GetConnectionString("MongoDb");
        services.AddScoped<IMongoClient, MongoClient>(sp => new MongoClient(mongoDbConnection));
        
        services.AddScoped<IMongoDatabase>(sp => sp.GetRequiredService<IMongoClient>().GetDatabase("store"));

        return services;
    }
}