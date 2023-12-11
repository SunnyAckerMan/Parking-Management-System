using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.DBContext;
using Repository.Repositories;
using Repository.UnitOfWorks;

namespace Repository.Extention;

public static class ConfigureServiceContainer
{
    public static void AddProjectDBContext(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
        services.AddDbContext<ParkingManagementDbContext>(options =>
        options.UseSqlServer(connectionString));
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IBaseRepository<>),typeof(BaseRepository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
