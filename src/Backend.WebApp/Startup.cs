// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using ExtCore.Data.EntityFramework;
using ExtCore.WebApplication.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection;

namespace WebApplication
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly string _extensionsPath;

        public Startup(IHostingEnvironment hostingEnvironment, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            this._configuration = configuration;
            this._extensionsPath = hostingEnvironment.ContentRootPath + this._configuration["Extensions:Path"];
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddExtCore(this._extensionsPath);

            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })

            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;

                options.ClientId = "ework-admin-dev";
                options.ClientSecret = "secret";
                options.ResponseType = "code id_token";

                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;

                options.Scope.Add("ework");
                options.Scope.Add("offline_access");

                options.ClaimActions.MapJsonKey("website", "website");
            })
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;

                options.ApiSecret = "secret";
                options.ApiName = "ework";
            });



            services.Configure<StorageContextOptions>(options =>
                {
                    options.ConnectionString = this._configuration.GetConnectionString("SQlServer");
                    options.MigrationsAssembly = typeof(DesignTimeStorageContextFactory).GetTypeInfo().Assembly.FullName;
                }
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My API", Version = "v1" });

                c.AddSecurityDefinition("oauth2", new Swashbuckle.AspNetCore.Swagger.OAuth2Scheme
                {
                    Flow = "implicit",
                    AuthorizationUrl = "http://localhost:5000/connect/authorize",
                    Scopes = new Dictionary<string, string> {
                        { "ework", "MoonlayEwork API" }
                    }
                });

                c.OperationFilter<Backend.WebApp.Swaggers.AuthorizeCheckOperationFilter>();
            });

            DesignTimeStorageContextFactory.Initialize(services.BuildServiceProvider());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment host)
        {
            if (host.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.OAuthClientId("ework-admin-swagger");
            });

            app.UseAuthentication();
            app.UseExtCore();
        }
    }
}