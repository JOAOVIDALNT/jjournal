using jjournal.Application.Services.Mapper;
using jjournal.Application.Services.Security;
using jjournal.Application.UseCases.User.Register;
using jjournal.Application.UseCases.User.Register.Validator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jjournal.Application
{
    public static class DIExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration config)
        {
            services.AddServices();
            services.AddUseCases();
            services.AddAutoMapper();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IRegisterUserValidator, RegisterUserValidator>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();
        }

        private static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        private static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new MappingConfig());
            }).CreateMapper());
        }
    }
}
