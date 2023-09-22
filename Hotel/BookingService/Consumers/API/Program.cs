using Application.Payment.Ports;
using Application.UseCases.Booking;
using IoC.Infrastructure;
using MediatR;
using Payment.Application;

var builder = WebApplication.CreateBuilder(args);

# region IoC
builder.Services.AddInfrastructure(builder.Configuration);
# endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddScoped<IPaymentProcessorFactory, PaymentProcessorFactory>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Middleware
app.UseMiddleware<HttpStatusCodeMiddleware>();
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
