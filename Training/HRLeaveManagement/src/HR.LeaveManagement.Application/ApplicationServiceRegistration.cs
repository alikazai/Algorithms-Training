using System.Reflection;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace HR.LeaveManagement.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}