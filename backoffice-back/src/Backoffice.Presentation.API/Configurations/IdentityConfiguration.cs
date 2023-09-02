using System.Text;
using Backoffice.Core;
using Backoffice.Infra.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Backoffice.Presentation.API.Configurations;

public static class IdentityConfiguration
{
    public static WebApplicationBuilder AddIdentityConfiguration(this WebApplicationBuilder builder)
    {
        var appSettingsSection = builder.Configuration.GetSection("Jwt");
        builder.Services.Configure<Jwt>(appSettingsSection);

        var appSettings = appSettingsSection.Get<Jwt>();
        var key = Encoding.ASCII.GetBytes(appSettings.Secret);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(bearerOption =>
        {
            bearerOption.RequireHttpsMetadata = true;
            bearerOption.SaveToken = true;
            bearerOption.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidIssuer = appSettings.Issuer
            };
        });

        builder.Services.AddDbContext<BackofficeContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddDefaultIdentity<IdentityUser>(options => { options.SignIn.RequireConfirmedEmail = true; })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<BackofficeContext>()
            .AddDefaultTokenProviders();

        return builder;
    }
}