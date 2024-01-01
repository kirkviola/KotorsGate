using KotorsGate.Application.Security;
using KotorsGate.Application.Security.Interfaces;
using KotorsGate.Application.Users;
using KotorsGate.Application.Users.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using KotorsGate.WebApp.Services;
using System.Text;
using KotorsGate.Application.Interfaces;
using KotorsGate.WebApp.Services.AuthRequirements;
using KotorsGate.WebApp.Services.AuthRequirements.AuthHandlers;
using KotorsGate.Application.Planets.Interfaces;
using KotorsGate.Application.Planets;
using Microsoft.AspNetCore.Authorization;
using KotorsGate.Application.Campaigns.Interfaces;
using KotorsGate.Application.Campaigns;

namespace KotorsGate.WebApp
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebAppServices(this IServiceCollection services, IConfiguration config) 
        {
            services.AddHttpContextAccessor();

            services.AddMvc(options => {
                // Resolve issue of having "async" in function names
                options.SuppressAsyncSuffixInActionNames = false;
            });

            // Jwt Auth
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = config["Jwt:Issuer"],
                        ValidAudience = config["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!))
                    };
                });

            // Add policies
            services.AddAuthorization(options => {
                // Policies will go here which will bind against permission checks
                // Use the sealed class instead of just string matching
                options.AddPolicy(SecurityRule.CampaignCreator, policy => {
                    policy.AddRequirements(new CampaignCreatorRequirement());
                });
                options.AddPolicy(SecurityRule.PlanetCreate, policy => {
                    policy.AddRequirements(new PlanetCreateRequirement());
                });
            });

            // Use case registry

            // Security and users
            services.AddScoped<IAuthenticateUser, AuthenticateUser>();
            services.AddScoped<IGetUserPermissions, GetUserPermissions>();
            services.AddScoped<IGetCurrentUser, GetCurrentUser>();
            services.AddScoped<IFindOneUserByUsername, FindOneUserByUsername>();
            services.AddScoped<IRegisterNewUser, RegisterNewUser>();
            services.AddScoped<IFindOneUserById, FindOneUserById>();
            services.AddSingleton<ISecurityService, SecurityService>();
            services.AddSingleton<IAuthorizationHandler, PlanetCreateRequirementHandler>();

            // Admin and structural
            services.AddScoped<IGetAllPlanets, GetAllPlanets>();
            services.AddScoped<IGetOnePlanetById, GetOnePlanetById>();
            services.AddScoped<IGetOnePlanetByName, GetOnePlanetByName>();
            services.AddScoped<ICreatePlanet, CreatePlanet>();
            services.AddScoped<IGetAllCampaigns, GetAllCampaigns>();
            services.AddScoped<IGetOneCampaignById, GetOneCampaignById>();
            services.AddScoped<IGetOneCampaignByName, GetOneCampaignByName>();

            return services;
        }
    }
}
