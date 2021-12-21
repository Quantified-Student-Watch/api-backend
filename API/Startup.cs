using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Repository;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace API
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
            services.AddDbContext<QsContext>(o =>
            {
                var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
                if (connectionString != null)
                {
                    o.UseSqlServer(connectionString,
                        sqlOptions => sqlOptions.EnableRetryOnFailure(50, TimeSpan.FromSeconds(30), null));
                }
            });
            services.AddControllers();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<IDataPointRepository, DataPointRepository>();
            services.AddScoped<IDataPointService, DataPointService>();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "API", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }
            
            using (var scope = 
                   app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<QsContext>())
                context?.Database.EnsureCreated();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}