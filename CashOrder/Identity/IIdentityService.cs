using System.Security;
using CashOrder.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CashOrder.Identity
{
    public interface IIdentityService
    {
        string GenerateJwtToken(IdentityUser user, string secret);

    }
}
