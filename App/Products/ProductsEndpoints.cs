using Microsoft.AspNetCore.Mvc;

namespace minimal_products_api.Endpoints;

public static class ProductsEndpoints
{
    public static WebApplication MapProductEndpoints(this WebApplication app)
    {
        app.MapPost("/products", () =>
            {
                return new OkObjectResult(new {});
            }).WithName("Create Products")
            .WithDescription("This endpoint creates a new Product to the Products collection in MongoDb..");

        return app;
    }

}