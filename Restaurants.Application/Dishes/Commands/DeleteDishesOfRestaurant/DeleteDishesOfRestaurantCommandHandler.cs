using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteDishesOfRestaurant;

public class DeleteDishesOfRestaurantCommandHandler(
    ILogger<DeleteDishesOfRestaurantCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IDishesRepository dishesRepository) : IRequestHandler<DeleteDishesOfRestaurantCommand>
{
    public async Task Handle(DeleteDishesOfRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Deleting all Dishes for Restaurant with Id: {@RestaurantId}.", request.RestaurantId);
        var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        await dishesRepository.Delete(restaurant.Dishes);
    }
}
