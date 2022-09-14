using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OIG.Survey.Domain.PipelineBehaviors;

namespace OIG.Survey.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDomain(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(ServiceCollectionExtensions));

        serviceCollection.AddMediatR(typeof(ServiceCollectionExtensions));

        serviceCollection.AddValidationSupport();
    }

    private static void AddValidationSupport(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }
}