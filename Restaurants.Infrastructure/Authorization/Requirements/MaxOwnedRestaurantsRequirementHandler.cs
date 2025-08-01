using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Repositories;
using System.Security.Claims;

namespace Restaurants.Infrastructure.Authorization.Requirements;

public class MaxOwnedRestaurantsRequirementHandler(
    ILogger<MaxOwnedRestaurantsRequirementHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IUserContext userContext
    ) : AuthorizationHandler<MaxOwnedRestaurantsRequirement>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, MaxOwnedRestaurantsRequirement requirement)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation("User: {Email} - Handling Max Owned Restaurants Requirement", user!.Email);

        var restaurants = await restaurantsRepository.GeAllAsync();
        var ownedRestaurantsCount = restaurants.Count(r => r.OwnerId == user!.Id);

        if (ownedRestaurantsCount <= requirement.MaxOwnedRestaurants)
        {
            logger.LogInformation("User: {Email} - Max Owned Restaurants Requirement [PASSED]", user!.Email);
            context.Succeed(requirement);
        }
        else
        {
            logger.LogWarning("User: {Email} have already exceeded the limit for creating restaurant", user!.Email);
            context.Fail();
        }


    }
}
