using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTO;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
{

    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Fetching all restaurants from the repository.");
        var restaurants = await restaurantsRepository.GeAllAsync();
        var restaurantDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        return restaurantDtos!;
    }

    public async Task<RestaurantDto?> GetRestaurantById(int id)
    {
        logger.LogInformation("Fetching a Restaurant By Id");
        var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(id);
        var restaurantDtos = mapper.Map<RestaurantDto>(restaurant);
        return restaurantDtos;
    }
    public async Task<int> Create(CreateRestaurantDto dto)
    {
        logger.LogInformation("Creating a new restaurant.");
        var restaurant = mapper.Map<Restaurant>(dto);
        var Id = await restaurantsRepository.CreateAsync(restaurant);
        return Id;
    }
}
