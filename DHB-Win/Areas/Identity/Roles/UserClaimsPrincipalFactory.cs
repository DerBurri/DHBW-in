using System.Security.Claims;
using System.Threading.Tasks;
using DHB_Win.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace DHB_Win.Areas.Identity.Roles;

public class UserClaimsPrincipalFactory :
    UserClaimsPrincipalFactory<User, IdentityRole>
{
    public UserClaimsPrincipalFactory(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<IdentityOptions> options
    ) : base(userManager, roleManager, options)
    {
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        identity.AddClaim(new Claim("Firstname", user.Firstname.ToString()));
        identity.AddClaim(new Claim("Name", user.Name.ToString()));
        return identity;
    }
}