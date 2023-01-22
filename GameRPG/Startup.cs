using GameRPG.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace GameRPG
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<Settings>(Configuration.GetSection("Settings"));
            var settings = Configuration.GetSection("Settings").Get<Settings>();

            #region Adicionar Log na aplica��o 
            SerilogProvider.CreateLogger(typeof(Startup).Namespace);

            Log.ForContext(SerilogProvider.Application, typeof(Startup).Namespace)
                .Information("Log adicionado na aplica��o.");

            services.AddSingleton(Log.ForContext(SerilogProvider.Application, typeof(Startup).Namespace));
            #endregion
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
