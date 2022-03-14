using Core.Interfaces;
using Core.Interfaces.StatusProduct;
using DataAccess.DataBase;
using DataAccess.Services.Product;
using DataAccess.Services.StatusProduct;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TechnicalTestITSense_APIRest.Filter;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;

namespace TechnicalTestITSense_APIRest
{
    public class Startup
    {
        private readonly string _Cors = "Cors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<TechnicalTestITSenseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TechnicalTestITSense"));
            });
            services.AddControllers();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IStatusProductService, StatusProductService>();
            services.AddTransient<TechnicalTestITSenseContext, TechnicalTestITSenseContext>();
            services.AddCors(optcion =>
            {
                optcion.AddPolicy(name: _Cors, builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
       


            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechnicalTestITSense_APIRestI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(_Cors);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

          
            app.UseSwagger(); app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechnicalTestITSense_APIRes");
            });


            app.UseDeveloperExceptionPage();

        }
    }
}
