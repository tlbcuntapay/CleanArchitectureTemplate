using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTO;
using Restaurants.Application.Users;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger,
    IMapper mapper,
    IUserContext userContext,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation("{Username} [{UserId}] is creating a new restaurant {@Restaurant}", user!.Email, user.Id, request);
        var restaurant = mapper.Map<Restaurant>(request);
        restaurant.OwnerId = user!.Id;
        var Id = await restaurantsRepository.CreateAsync(restaurant);
        return Id;
    }
}
