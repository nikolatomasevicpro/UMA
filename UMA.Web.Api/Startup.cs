using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using UMA.App.Common.Configuration;
using UMA.App.IdentityManager;
using UMA.Persistence.Identity.Context;

namespace UMA.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.GetSection(nameof(APIConfiguration)).Bind(APIConfiguration.Intance);

            services.AddAutoMapper(new Assembly[] { typeof(IdentityManagerReferencer).GetTypeInfo().Assembly });

            services.AddMediatR(typeof(IdentityManagerReferencer).GetTypeInfo().Assembly);

            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(APIConfiguration.Intance.ConnectionStrings["IdentityConnection"]));

            //services.AddIdentity<UserIdentity, IdentityRole>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = APIConfiguration.Intance.JwtConfig.Issuer,
                    ValidAudience = APIConfiguration.Intance.JwtConfig.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(APIConfiguration.Intance.JwtConfig.Key)),
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true,
                    RequireSignedTokens = true
                };
            });

            if ((APIConfiguration.Intance.PoliciesMapping?.Count ?? 0) > 0)
            {
                services.AddAuthorization(options =>
                {
                    foreach (var item in APIConfiguration.Intance.PoliciesMapping)
                    {
                        if ((item.Value?.Count ?? 0) > 0)
                        {
                            options.AddPolicy(item.Key, policy =>
                            {
                                policy.RequireAuthenticatedUser();

                                if (item.Value.Count == 1)
                                {
                                    policy.RequireClaim(item.Value[0]);
                                }
                                else
                                {
                                    policy.RequireAssertion(context => item.Value.Any(c => context.User.HasClaim(x => x.Type == c)));
                                }
                            });
                        }
                    }
                });
            }

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IdentityManagerReferencer>());

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                .Build());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors("CorsPolicy");

            app.UseMvc();
        }
    }
}
