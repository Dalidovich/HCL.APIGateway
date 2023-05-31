
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace HCL.APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var ocelotConfigPath = builder.Configuration.GetSection("Ocelot:JsonConfig").Value?? "ocelot.json";
            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(ocelotConfigPath, optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            builder.Services.AddOcelot(builder.Configuration);

            var app = builder.Build();

            app.UseOcelot();
            app.Run();
        }
    }
}