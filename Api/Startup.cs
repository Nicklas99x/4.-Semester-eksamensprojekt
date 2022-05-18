using Api.Controllers;
using Application.Models;
using Machine_Learning;
using Machine_Learning.Container;
using Machine_Learning.Interfaces;
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

namespace Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });
            services.AddScoped<IDataLoader, DataLoader>();
            services.AddScoped<IDataManager, DataManager>();
            services.AddScoped<IMLPipeline, MlPipeline>();
            services.AddScoped<IModelTrainer, ModelTrainer>();
            services.AddScoped<IModelEvaluator, ModelEvaluator>();
            services.AddScoped<IPricePredictor, PricePredictor>();

            services.AddScoped<IModelScoreRequestObject, ModelScoreRequestObject>();
            services.AddScoped<IPricePredictionRequestObject, PricePredictionRequestObject>();
            services.AddScoped<IPredictedPricesRequestObject, PredictedPricesRequestObject>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
