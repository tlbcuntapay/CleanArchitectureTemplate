using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Interfaces;

namespace Restaurants.Infrastructure.Authorization.Services;

public class RestaurantAuthorizationService(
    ILogger<RestaurantAuthorizationService> logger,
    IUserContext userContext
    ) : IRestaurantAuthorizationService
{
    public bool Authorize(Restaurant restaurant, ResourceOperation resourceOperation)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation("User: {Email} - Authorizing {Operation} on Restaurant [{RestaurantName}]", user!.Email, resourceOperation, restaurant.Name);

        if (resourceOperation == ResourceOperation.Read || resourceOperation == ResourceOperation.Create)
        {
            logger.LogInformation("Authorization Succeeded for {Operation} on Restaurant [{RestaurantName}]", resourceOperation, restaurant.Name);
            return true;
        }

        if (resourceOperation == ResourceOperation.Delete && user.IsInRole(UserRoles.Admin))
        {
            logger.LogInformation("Admin Authorization Succeeded for {Operation} on Restaurant [{RestaurantName}]", resourceOperation, restaurant.Name);
            return true;
        }

        if (resourceOperation == ResourceOperation.Update || resourceOperation == ResourceOperation.Delete && user.Id == restaurant.OwnerId)
        {
            logger.LogInformation("Admin Authorization Succeeded for {Operation} on Restaurant [{RestaurantName}]", resourceOperation, restaurant.Name);
            return true;
        }

        return false;
    }
}
