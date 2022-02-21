using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RubiksTangle.Application.Features;
using RubiksTangle.Application.PipelineBehavior;
using RubiksTangle.Core;
using RubiksTangle.Web.Exception;
using System.Reflection;

namespace RubiksTangle.Web
{
    public class Startup
    {
        public ILifetimeScope AutofacContainer { get; private set; }
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.Load("RubiksTangle.Application");
            services.AddMediatR(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddControllers();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "rubiks-tangle/dist";
            });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {

            var contextBuilder = new DbContextOptionsBuilder<RubikDbContext>();
            contextBuilder.UseSqlServer(Configuration.GetConnectionString("RubiksTangle"));
            builder.RegisterType(typeof(HttpContextAccessor)).As(typeof(IHttpContextAccessor)).SingleInstance();
            builder.RegisterType<RubikDbContext>()
                .WithParameter("options", contextBuilder.Options)
                .InstancePerLifetimeScope()
                .AsSelf();
            builder.RegisterType<GameSolutionService>().InstancePerLifetimeScope().As<IGameSolutionService>();
            builder.RegisterType<RotationService>().InstancePerLifetimeScope().As<IRotationService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app, env);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller}/{action}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "rubiks-tangle";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
        }
        static void UpdateDatabase(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) return;
            using (IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (RubikDbContext context = serviceScope.ServiceProvider.GetService<RubikDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
