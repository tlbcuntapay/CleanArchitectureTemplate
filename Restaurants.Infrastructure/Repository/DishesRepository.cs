using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repository
{
    internal class DishesRepository(RestaurantsDbContext dbContext) : IDishesRepository
    {
        public async Task<int> CreateDishesAsync(Dish dish)
        {
            await dbContext.Dishes.AddAsync(dish);
            await dbContext.SaveChangesAsync();
            return dish.Id;
        }

        public async Task Delete(IEnumerable<Dish> dish)
        {
            dbContext.Dishes.RemoveRange(dish);
            await dbContext.SaveChangesAsync();
        }
    }
}
