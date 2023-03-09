using System.Runtime.CompilerServices;
using Lin.Pay.BaoFoo;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddBaoFoo(this IServiceCollection services, BaoFooOptions options)
    {
        services.AddHttpClient();
        
        services.AddSingleton(options);
        services.AddSingleton<IBaoFooClient, BaoFooClient>();
        services.AddSingleton<IBaoFooNotifyClient, BaoFooNotifyClient>();
    }

    public static void AddBaoFoo(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetSection(nameof(BaoFooOptions)).Get<BaoFooOptions>();
        AddBaoFoo(services, options);
    }
}