using System;
using System.Threading.Tasks;
using Grpc.Client.Commands;
using Grpc.Net.Client;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static Grpc.Proto.Greeter;

namespace Grpc.Client
{
    [Command("grpc-client", Description = "Client for gRPC Service"),
     Subcommand(typeof(Send))]
    public class Program
    {
        [Option(Inherited = true)]
        public bool Verbose { get; set; }

        public static async Task<int> Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            await CreateHostBuilder(args).RunCommandLineApplicationAsync<Program>(args);
            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton(provider => new Func<string, GreeterClient>((channel) => new GreeterClient(GrpcChannel.ForAddress(channel))));
                });
        public async Task OnExecuteAsync(CommandLineApplication app)
        {
            await Task.Run(() => app.ShowHelp());
        }
    }
}
