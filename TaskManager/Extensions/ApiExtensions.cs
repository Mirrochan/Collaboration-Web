using Infrastructure.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text;


namespace TaskManager.Extentions
{
    public static class ApiExtensions
    {
        public static void GetApiAuthentification(
            this IServiceCollection services,
            IOptions<JwtOptions> jwtOptions
            )
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
           {
               options.TokenValidationParameters = new()
               {
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey))
               };

               options.Events = new JwtBearerEvents
               {
                   OnMessageReceived = context =>
                   {
                       context.Token = context.Request.Cookies["tasty-cookies"];
                       return Task.CompletedTask;
                   }
               };
            });

            services.AddAuthentication();
        }
    }
}
