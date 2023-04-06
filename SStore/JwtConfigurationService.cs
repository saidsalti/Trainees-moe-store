using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SStore.Pages.Products;
using System.Text;

namespace SStore
{
    public static class JwtConfigurationService
    {
        public static IServiceCollection AddJwtServce(this IServiceCollection services,IConfiguration  configuration)
        {

            // Add JWT authentication
         services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration.GetValue<string>("Issuer"),
                ValidAudience = configuration.GetValue<string>("Audience"),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration!.GetValue<string>("JwtSecret")!))
            };
        });
            return services;
        }
    }
}
