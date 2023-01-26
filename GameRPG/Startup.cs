using GameRPG.Domain.Model;
using GameRPG.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using GameRPG.Application.AutofacModules;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using GameRPG.Infrastructure;

namespace GameRPG
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; protected set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment hosting)
        {

#if DEBUG
            var builder = new ConfigurationBuilder().SetBasePath(hosting.ContentRootPath)
                                        .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
#else
            var builder = new ConfigurationBuilder().SetBasePath(hosting.ContentRootPath)
                                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
#endif

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public virtual IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.Configure<Settings>(Configuration.GetSection("Settings"));
            var settings = Configuration.GetSection("Settings").Get<Settings>();

            #region Adicionar Log na aplicação 
            SerilogProvider.CreateLogger(typeof(Startup).Namespace, settings);

            Log.ForContext(SerilogProvider.Application, typeof(Startup).Namespace)
                .Information("Log adicionado na aplicação.");

            services.AddSingleton(Log.ForContext(SerilogProvider.Application, typeof(Startup).Namespace));
            #endregion


            Log.ForContext(SerilogProvider.Application, typeof(Startup).Namespace)
            .Information("Adicionado injeção de dependencia na aplicação.");

            services.AddMvc(options =>
            {
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers();


            #region Swagger
            services.AddSwaggerGen(config =>
            {

                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Game RPG",
                    Version = "v1"
                });
            });
            #endregion

            services.AddMemoryCache();

            var container = new ContainerBuilder();
            container.Populate(services);

            //Injeção dos modulos 
            container.RegisterModule(new ApplicationModule());
            container.RegisterModule(new MediatorModule());

            return new AutofacServiceProvider(container.Build());

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var supportedCultures =
                new[] { "pt-BR", "pt", "en-US", "en", "es-ES", "es" }
                    .Select(x => new CultureInfo(x)).ToList();

            var requestLocalizationOptions = new RequestLocalizationOptions
            {
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                DefaultRequestCulture = new RequestCulture(supportedCultures[0])
            };

            app.UseRequestLocalization(requestLocalizationOptions);
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
