using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.DTO;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantController(IRestaurantsService restaurantService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restaurantService.GetAllRestaurants();
        return Ok(restaurants);
    }

    [HttpGet("{id}")] 
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await restaurantService.GetRestaurantById(id);

        if (restaurant is null)
            return NotFound("The Restaurant doesn't exist.");

        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
    {
        var id = await restaurantService.Create(createRestaurantDto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

}
