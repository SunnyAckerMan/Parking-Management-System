using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Extention;
using Service.Services.Billing;
using Service.Services.ParkingSpot;
using Service.Services.Rate;
using Service.Services.Ticket;

namespace Service.Extention;

public static class ConfigureServiceContainer
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
        //Dependency Injection
        services.AddTransient<IParkingSpotService, ParkingSpotService>();
        services.AddTransient<IBillingService, BillingService>();
        services.AddTransient<IRateService, RateService>();
        services.AddTransient<ITicketService, TicketService>();

        //Context & Repository Injection
        services.AddProjectDBContext(configuration, connectionString);
        services.AddRepositories();
    }

}
