using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSupply.Products.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using SSupply.Products.Services;
using SSupply.Products.Data.Managers;
using SSupply.Products.Data.Repositories;
using SSupply.Products.Data.Interfaces;
using SSupply.Products.Interfaces;
using AutoMapper;
using SSupply.Products.Api.Interfaces;

namespace SSupply.Products.Api
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
            var connectionString = Configuration.GetConnectionString("ProductsDb");

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ProductsDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<DbContext, ProductsDbContext>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddAutoMapper();
            services.AddMvc();

            services.AddSwaggerGen(opt =>
                {
                    opt.SwaggerDoc("v1", new Info { Title = "Products API" });
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            var swaggerPath = Configuration["SwaggerPath"];

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint(swaggerPath, "Products API");
            });

            app.UseMvc();
        }
    }
}
