using System;
using Abp.AspNetCore;
using Abp.AspNetCore.Mvc.Antiforgery;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.Castle.Logging.Log4Net;
using ABP.SP.Authentication.JwtBearer;
using ABP.SP.Configuration;
using ABP.SP.Identity;
using ABP.SP.Web.Resources;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.WebEncoders;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

namespace ABP.SP.Web.Startup;

public class Startup(IWebHostEnvironment env)
{
    private readonly IConfigurationRoot _appConfiguration = env.GetAppConfiguration();
    private readonly string _apiVersion = "v1.0";

    public void ConfigureServices(IServiceCollection services)
    {
        // MVC
        services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                options.Filters.Add(new AbpAutoValidateAntiforgeryTokenAttribute());
            }
        );

        IdentityRegistrar.Register(services);
        AuthConfigurer.Configure(services, _appConfiguration);

        services.Configure<WebEncoderOptions>(options =>
        {
            options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
        });

        services.AddScoped<IWebResourceManager, WebResourceManager>();

        services.AddSignalR();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(_apiVersion, new OpenApiInfo
            {
                Version = _apiVersion,
                Title = "ABP.SP API",
                Description = "RumpleSteelSkin Sample ABP Project",
                Contact = new OpenApiContact
                {
                    Name = "RumpleSteelSkin",
                    Email = "example@example.com",
                    Url = new Uri("https://github.com/RumpleSteelSkin/ABP.SP")
                }
            });
            
            options.DocInclusionPredicate((docName, apiDesc) =>
            {
                if (apiDesc.ActionDescriptor is not ControllerActionDescriptor controllerActionDescriptor)
                    return false;
                
                return controllerActionDescriptor.ControllerTypeInfo
                           .GetCustomAttributes(typeof(ApiControllerAttribute), true).Length != 0 ||
                       (apiDesc.RelativePath?.StartsWith("api/") ?? false);
            });
            
            options.CustomSchemaIds(type => type.FullName);

            options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
            {
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                BearerFormat =  "JWT",
                Scheme = "bearer"
            });
        });

        // Configure Abp and Dependency Injection
        services.AddAbpWithoutCreatingServiceProvider<SPWebMvcModule>(
            // Configure Log4Net logging
            options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseAbpLog4Net().WithConfig(
                    env.IsDevelopment()
                        ? "log4net.config"
                        : "log4net.Production.config"
                )
            )
        );
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        app.UseAbp(); // Initializes ABP framework.

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseJwtTokenMiddleware();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<AbpCommonHub>("/signalr");
            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
        });

        app.UseSwagger(options => { options.RouteTemplate = "swagger/{documentName}/swagger.json"; });
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint($"/swagger/{_apiVersion}/swagger.json", $"ABP.SP API {_apiVersion}");
            options.DisplayRequestDuration();
        });
    }
}