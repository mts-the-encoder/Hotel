namespace Application.Services.Abstractions;

public interface IExceptionLoggerService
{
    Task Log(Exception exception, string? requestPath);
}