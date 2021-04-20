using Infrastructure.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Startup
    {
        #region Properties

        public IConfiguration Configuration { get; }

        #endregion Properties

        #region Constructors

        public Startup(IConfiguration configuration) => Configuration = configuration;

        #endregion Constructors

        #region Methods

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api V1");
                options.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructureLayer(Configuration);

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        #endregion Methods
    }
}
