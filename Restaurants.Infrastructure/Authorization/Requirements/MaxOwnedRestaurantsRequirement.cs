using Microsoft.AspNetCore.Authorization;

namespace Restaurants.Infrastructure.Authorization.Requirements;

public class MaxOwnedRestaurantsRequirement(int maxOwnedRestaurants) : IAuthorizationRequirement
{
    public int MaxOwnedRestaurants { get; set; } = maxOwnedRestaurants;
}
