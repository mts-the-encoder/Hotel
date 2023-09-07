using Application.Services.Abstractions;
using Data;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace Application.Services;

public class ExceptionLoggerService : IExceptionLoggerService
{
    private readonly IServiceProvider _serviceProvider;

    public ExceptionLoggerService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Log(Exception exception, string? requestPath)
    {
        using var scope = _serviceProvider.CreateScope();
        await using var context = scope.ServiceProvider.GetService<HotelDbContext>();
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(exception.Message);

        var innerException = exception.InnerException;
        while (innerException != null)
        {
            stringBuilder.Append($"\r\n{innerException.Message}");
            innerException = innerException.InnerException;
        }

        if (context != null)
        {
            context.ExceptionLogs.Add(new ExceptionLog
            {
                Error = exception.Source,
                Path = requestPath,
            });

            await context.SaveChangesAsync();
        }
    }
}