using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteDishesOfRestaurant;

public class DeleteDishesOfRestaurantCommand(int restaurantId) : IRequest
{
    public int RestaurantId { get; set; } = restaurantId;
}
