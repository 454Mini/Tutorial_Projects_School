using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TourOfHeroes.Services;

namespace TourOfHeroes
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IHeroService, HeroService>(); 
            //Tilføj ny SINGLETON service: 
            //Kun en instans af denne
            //Keeps state, så vi altid kalder den samme, og ikke forskellige vesrionser. 
            //Client side, ikke så vigtigt, da ingen vil som på en server, kunne hente den
            builder.Services.AddSingleton<IMessagingService, MessagingService>();

            await builder.Build().RunAsync();
        }
    }
}
