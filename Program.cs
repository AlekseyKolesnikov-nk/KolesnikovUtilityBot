using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
 
namespace KolesnikovUtilityBot
{
    static class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
           
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services))
                .UseConsoleLifetime()
                .Build();
 
            Console.WriteLine("Сервис стартовал");
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");
        }
       
        static  void ConfigureServices(IServiceCollection services)
         {
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("7615351480:AAG916o5vCqGy-2bNuMjRUel6JAdrDzgkAY"));
            services.AddHostedService<Bot>();
         }
    }
}