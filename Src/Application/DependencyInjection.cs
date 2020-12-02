using AutoMapper;
using FinRust.Application.Calculation.Interfaces;
using FinRust.Application.Calculation.Services;
using FinRust.Application.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FinRust.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            //Services
            services.AddScoped<IGetAmount, CalculatorHelper>();
            services.AddScoped<IGetCashFlowAmount, CalculationService>();
            services.AddScoped<ICalculateAOW, CalculationService>();

            return services;
        }
    }
}
