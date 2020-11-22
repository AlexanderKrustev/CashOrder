namespace CashOrder.Infrastructure
{
    using Data;
    using Identity;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using Document;
    using Firms;
    using Microsoft.OpenApi.Models;

    public static class ConfigureServices
    {

        public static IServiceCollection AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<CoDbContext>();

            
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection service)
        => service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cash Order", Version = "v1" });
            });

        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }

        public static IServiceCollection AddInjectedServices(this IServiceCollection services)
           => services.AddTransient<IIdentityService, IdentityService>()
               .AddTransient<IFirmService,FirmServices>()
               .AddTransient<IDocumentService, DocumentServices>();
        
    }
}
