using AutoMapper;
using BikeManager.API.Mapping;
using BikeManager.API.Services;
using BikeManager.API.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BikeManager.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add service for DI
        /// </summary>
        /// <param name="services"></param>
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBikeService), typeof(BikeService));
            services.AddTransient(typeof(IBikeStatusService), typeof(BikeStatusService));
            services.AddTransient(typeof(IBikeCategoryService), typeof(BikeCategoryService));
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            var mapperConfig = new MapperConfiguration(expression =>
            {
                expression.AddProfile(new BikeMapping());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}