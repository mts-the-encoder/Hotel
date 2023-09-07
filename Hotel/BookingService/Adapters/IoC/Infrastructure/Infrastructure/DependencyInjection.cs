using Application.Guest.Ports;
using Application.Services;
using Application.Services.Abstractions;
using Application.Services.Mapper;
using Application.UseCases.Guest;
using Data;
using Data.Repositories;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HotelDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(HotelDbContext).Assembly.FullName)));

        services.AddSingleton<IExceptionLoggerService, ExceptionLoggerService>();
        services.AddScoped<IGuestRepository, GuestRepository>();
        services.AddScoped<IGuestManager, GuestManager>();
        services.AddAutoMapper(typeof(AutoMapperConfiguration));


        return services;
    }
}