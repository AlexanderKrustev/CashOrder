namespace CashOrder.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class UserEntityModel : IdentityUser
    {
        public string Name { get; set; }

    }
}
