using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>> GeAllAsync();

    Task<Restaurant?> GetRestaurantByIdAsync(int id);
    Task<int> CreateAsync(Restaurant restaurant);
    Task Delete(Restaurant restaurant);
    Task SaveChanges();
}
