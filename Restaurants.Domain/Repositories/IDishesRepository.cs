using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IDishesRepository
{
    Task<int> CreateDishesAsync(Dish dish);
    Task Delete(IEnumerable<Dish> dish);
}
