﻿using Application.Booking.Ports;
using Application.Guest.Ports;
using Application.Payment.Ports;
using Application.Room.Ports;
using Application.Services;
using Application.Services.Abstractions;
using Application.Services.Mapper;
using Application.UseCases.Booking;
using Application.UseCases.Guest;
using Application.UseCases.Room;
using Data;
using Data.Repositories;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment.Application.MercadoPago;

namespace IoC.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HotelDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(HotelDbContext).Assembly.FullName)));

        services.AddSingleton<IExceptionLoggerService, ExceptionLoggerService>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IGuestRepository, GuestRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IBookingManager, BookingManager>();
        services.AddScoped<IGuestManager, GuestManager>();
        services.AddScoped<IRoomManager, RoomManager>();
        services.AddScoped<IPaymentProcessor, MercadoPagoAdapter>();
        services.AddAutoMapper(typeof(AutoMapperConfiguration));

        var myHandlers = AppDomain.CurrentDomain.Load("Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myHandlers));

        return services;
    }
}