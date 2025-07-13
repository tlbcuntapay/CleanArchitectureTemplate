using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger) : IRestaurantsService
{
    public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
    {
        logger.LogInformation("Fetching all restaurants from the repository.");
        var restaurants = await restaurantsRepository.GeAllAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetRestaurantById(int id)
    {
        logger.LogInformation("Fetching a Restaurant By Id");
        var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(id);
        return restaurant;
    }
}
