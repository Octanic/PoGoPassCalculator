using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PoGoPassCalculator.Models;
using PoGoPassCalculator.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PoGoPassCalculator
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<CalculatorService>();
            builder.Services.AddSingleton<CalculatorConfiguration>();

            var app = builder.Build();

            var singleton = app.Services.GetService<CalculatorConfiguration>();
            singleton.BundlesToCompare = new List<Bundle>()
            {
                new Bundle(){ PassQuantity=16, PassType = Bundle.BundlePassType.Premium, Value = 1480},
                new Bundle(){ PassQuantity=3, PassType = Bundle.BundlePassType.Remoto, Value = 250},
            };
            
            await app.RunAsync();
        }
    }
}
