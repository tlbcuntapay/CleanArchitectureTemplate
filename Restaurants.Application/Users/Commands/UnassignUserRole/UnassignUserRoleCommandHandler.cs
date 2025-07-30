using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users.Commands.UnassignUserRole;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Commands.DeleteUserRole;

public class UnassignUserRoleCommandHandler(
    ILogger<UnassignUserRoleCommandHandler> logger,
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager

    ) : IRequestHandler<UnassignUserRoleCommand>
{
    public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Deleting Role of user: {@Request}", request);
        
        // Validate user and role if exist
        var user = await userManager.FindByEmailAsync(request.Email) ?? throw new NotFoundException(nameof(User), request.Email);
        var role = await roleManager.FindByNameAsync(request.RoleName) ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

        await userManager.RemoveFromRoleAsync(user, role.Name!);
    }
}
