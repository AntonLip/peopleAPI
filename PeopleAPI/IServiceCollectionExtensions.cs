using Microsoft.Extensions.DependencyInjection;
using PeopleAPI.DataAccess;
using PeopleAPI.Models.Interfaces;
using PeopleAPI.Models.Interfaces.Repository;
using PeopleAPI.Models.Interfaces.Services;
using PeopleAPI.Services;

namespace PeopleAPI
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPositionTransient(this IServiceCollection services)
        {
            services.AddTransient<IPositionRepository, PositionRepository>();
            services.AddTransient<IPositionServices, PositionService>();
        }

        public static void AddUnitTransient(this IServiceCollection services)
        {
            services.AddTransient<IUnitRepository, UnitRepository>();
            services.AddTransient<IUnitServices, UnitService>();
        }

        public static void AddCadetTransient(this IServiceCollection services)
        {
            services.AddTransient<ICadetRepository, CadetRepository>();
            services.AddTransient<ICadetService, CadetService>();
        }
        public static void AddRanksTransient(this IServiceCollection services)
        {
            services.AddScoped<IMilitaryRankRepository, MilitaryRankRepository>();
            services.AddScoped<IMilitaryRankService, MilitaryRankService>();
        }
        public static void AddOficerTransient(this IServiceCollection services)
        {
            services.AddScoped<IOficerRepository, OficerRepository>();
            services.AddScoped<IOficerService, OficerService>();
        }

    }
}

