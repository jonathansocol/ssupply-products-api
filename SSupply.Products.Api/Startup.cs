using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSupply.Products.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;

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

            services.AddDbContext<ProductsDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddMvc();

            services.AddSwaggerGen(opt =>
                {
                    opt.SwaggerDoc("Products API", new Info { Title = "Products API" });
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

            var swaggerPath = Configuration["SwaggerPath"];

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint(swaggerPath, "Products API");
            });

            app.UseMvc();
        }
    }
}
