using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace Grpc.Client.Commands
{
    [Command("send", Description = "Send <RPC>"),
     Subcommand(typeof(SendHello))]
    public class Send
    {
        [Option(Inherited = true, Description = "Default: 'http://localhost:80'")]
        public string Channel { get; set; } = "http://localhost:80";
        public async Task OnExecuteAsync(CommandLineApplication app)
        {
            await Task.Run(() => app.ShowHelp());
        }
    }

    public abstract class SendBase
    {
        public Send? Parent { get; }
    }
}
