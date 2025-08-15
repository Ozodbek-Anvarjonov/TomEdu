using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Infrastructure.Common.Identities;
using TomEdu.Application.Abstractions.Caching.Brokers;
using TomEdu.Application.Abstractions.Identity;
using TomEdu.Application.Abstractions.Notifications.Channels;
using TomEdu.Application.Abstractions.Notifications.Credentials;
using TomEdu.Application.Abstractions.Notifications.Services;
using TomEdu.Application.Abstractions.Notifications.Templates;
using TomEdu.Application.Abstractions.Persistence;
using TomEdu.Application.Abstractions.Persistence.UnitOfWork;
using TomEdu.Application.Services;
using TomEdu.Infrastructure.Caching;
using TomEdu.Infrastructure.Identities;
using TomEdu.Infrastructure.Notifications.Channels;
using TomEdu.Infrastructure.Notifications.Credentials;
using TomEdu.Infrastructure.Notifications.Credentials.Emails;
using TomEdu.Infrastructure.Notifications.Credentials.Sms;
using TomEdu.Infrastructure.Notifications.Services;
using TomEdu.Infrastructure.Notifications.Templates;
using TomEdu.Infrastructure.Notifications.Templates.Emails;
using TomEdu.Infrastructure.Notifications.Templates.Sms;
using TomEdu.Infrastructure.Persistence.DataContexts;
using TomEdu.Infrastructure.Persistence.Repositories;
using TomEdu.Infrastructure.Persistence.UnitOfWork;
using TomEdu.Infrastructure.Services;
using TomEdu.Persistence.Interceptors;

namespace TomEdu.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddPersisnteceServices();

        return services;
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditCreationInterceptor>();
        services.AddScoped<AuditModificationInterceptor>();
        services.AddScoped<AuditDeletionInterceptor>();

        //services.AddScoped<DbContext>();

        services.AddDbContext<DbContext, AppDbContext>((provider, options) =>
        {
            var auditCreationInterceptor = provider.GetRequiredService<AuditCreationInterceptor>();
            var auditModificationInterceptor = provider.GetRequiredService<AuditModificationInterceptor>();
            var auditDeletionInterceptor = provider.GetRequiredService<AuditDeletionInterceptor>();

            options
                .UseNpgsql(configuration.GetConnectionString("DefaultDbConnection"))
                .AddInterceptors(auditCreationInterceptor)
                .AddInterceptors(auditModificationInterceptor)
                .AddInterceptors(auditDeletionInterceptor);
        });
    }

    private static void AddPersisnteceServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructureServices();
        services.AddIdentities();
        services.AddCaching();
        services.AddNotifications(configuration);

        return services;
    }

    private static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();

        return services;
    }

    private static IServiceCollection AddIdentities(this IServiceCollection services)
    {
        services.AddScoped<IAccessTokenGeneratorService, AccessTokenGeneratorService>();
        services.AddScoped<IRefreshTokenGeneratorService, RefreshTokenGeneratorService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<IPasswordHasherService, PasswordHasherService>();
        services.AddScoped<IAuthService, AuthService>();
        //services.AddScoped<IAccountService, AccountService>();

        return services;
    }

    private static IServiceCollection AddCaching(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<ICacheBroker, MemoryCacheBroker>();
        //services.AddSingleton<ICacheBroker, RedisDistributedCacheBroker>();
        //services.AddDistributedMemoryCache();

        return services;
    }

    private static IServiceCollection AddNotifications(this IServiceCollection services, IConfiguration configuration)
    {
        // services
        services.AddScoped<IEmailService, SmtpEmailService>();
        services.AddScoped<ISmsService, EskizSmsService>();

        // base
        services.AddScoped<INotificationSenderService, NotificationSenderService>();
        services.AddScoped<INotificationChannelProvider, NotificationChannelProvider>();
        services.AddScoped<INotificationTemplateProvider, NotificationTemplateProvider>();
        services.AddScoped<INotificationCredentialProvider, NotificationCredentialProvider>();

        // templates
        // email
        services.AddScoped<INotificationTemplate, RegisterEmailNotificationTemplate>();
        services.AddScoped<INotificationTemplate, LoginEmailNotificationTemplate>();
        services.AddScoped<INotificationTemplate, ChangePasswordEmailNotificationTemplate>();

        // sms
        services.AddScoped<INotificationTemplate, RegisterSmsNotificationTemplate>();
        services.AddScoped<INotificationTemplate, LoginSmsNotificationTemplate>();
        services.AddScoped<INotificationTemplate, ChangePasswordSmsNotificationTemplate>();


        // channels
        services.AddScoped<INotificationChannel, EmailNotificationChannel>();
        services.AddScoped<INotificationChannel, SmsNotificationChannel>();

        // credentials
        services.AddScoped<INotificationCredential, RegisterSmsNotificationCredential>();
        services.AddScoped<INotificationCredential, RegisterEmailNotificationCredential>();
        services.AddScoped<INotificationCredential, LoginEmailNotificationCredential>();

        return services;
    }
}