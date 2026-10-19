using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace BanHangQuanTraSua.Configurations;

public static class ConfigurationHelper
{
    private static IConfiguration? _configuration;

    public static IConfiguration Configuration
    {
        get
        {
            if (_configuration == null)
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var builder = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                _configuration = builder.Build();
            }
            return _configuration;
        }
    }

    public static PaymentConfig GetPaymentConfig()
    {
        var config = new PaymentConfig();
        Configuration.GetSection("Payment").Bind(config);
        return config;
    }

    public static string GetConnectionString()
    {
        return Configuration.GetConnectionString("QL_TraSua")
               ?? "Server=localhost;Database=QL_TraSua;User Id=sa;Password=SuperPass@123;TrustServerCertificate=True;";
    }
}
