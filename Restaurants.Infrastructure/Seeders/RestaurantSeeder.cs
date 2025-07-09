using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = [
            new ()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description = "KFChan sa sarap",
                ContactEmail = "kfc@email.com",
                HasDelivery = true,
                Dishes =
                [
                    new ()
                    {
                        Name = "Chicken Bucket",
                        Description = "A bucket",
                        Price = 299.99m
                    },
                    new ()
                    {
                        Name = "Nashville Hot Chicken",
                        Description = "10 pc hot chicken",
                        Price = 19.99m
                    },
                ],
                Address = new ()
                {
                    City = "Manila",
                    Street = "123 KFC St",
                    PostalCode = "1000"
                }
            },
            new ()
            {
                Name = "Jollibee",
                Category = "Fast Food",
                Description = "The best chickenjoy in town",
                ContactEmail = "contact@jollibee.com",
                HasDelivery = true,
                Address = new()
                {
                    City = "Quezon City",
                    Street = "456 Jollibe",
                    PostalCode = "1100"
                }
            }
        ];

        return restaurants;
    }
}
