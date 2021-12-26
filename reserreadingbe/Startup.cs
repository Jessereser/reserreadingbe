using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.OpenApi.Models;
using reserreadingbe.Data;
using Microsoft.AspNetCore.SignalR;

namespace reserreadingbe
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        private readonly string reserreadingdb = "Server=localhost;Database=reserreadingdb;Uid=root;Pwd=Floortje02;";
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ReserreadingbeContext>(options =>
                options.UseMySql(reserreadingdb, ServerVersion.AutoDetect(reserreadingdb)));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "reserreadingbe", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "reserreadingbe v1"));
            }

            using (IServiceScope scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<ReserreadingbeContext>())
                context.Database.EnsureCreated();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=dashboard}/{action=index}/{id?}"
                );
                endpoints.MapHub<ReserreadingbeHub>("/hub");
            });
            
        }
    }
}