using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using PoC.SendEmail.API.Application.Commands.CreateSubscriber;
using PoC.SendEmail.API.Application.Commands.GetAllSubscriber;
using PoC.SendEmail.API.Application.Common;
using PoC.SendEmail.API.Application.Mappings.SubscriberMapper;
using PoC.SendEmail.API.Domain.Interfaces;
using PoC.SendEmail.API.Infrastructure.Data;
using PoC.SendEmail.API.Infrastructure.Repositories;
using System.Data;
using System.Reflection;

namespace PoC.SendEmail.API.Infrastructure.IoC;

public static class ServiceConfiguration
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddSingleton<MySqlConnectionFactory>();
        services.AddTransient<IDbConnection>(sp =>
        {
            var connectionString = configuration.GetConnectionString("EcommerceConnection");
            return new MySqlConnection(connectionString);
        });
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(typeof(SubscriberMappingProfile));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        services.AddTransient<IRequestHandler<CreateSubscriberRequest, string>, CreateSubscriberCommandHandler>();
        services.AddScoped<ISubscriberRepository, SubscriberRepository>();
        services.AddTransient<IRequestHandler<GetAllSubscribersRequest, List<GetAllSubscribersResponse>>, GetAllSubscribersQueryHandler>();
    }
}