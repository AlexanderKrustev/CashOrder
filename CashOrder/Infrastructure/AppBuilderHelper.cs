namespace CashOrder.Infrastructure
{
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class AppBuilderHelper
    {
        public static void  Migrate(IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var ctx = scope.ServiceProvider.GetRequiredService<CoDbContext>();

            ctx.Database.Migrate();

   
        }
    }
}
