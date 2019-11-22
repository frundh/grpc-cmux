using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Grpc.Proto;
using McMaster.Extensions.CommandLineUtils;
using static Grpc.Proto.Greeter;

namespace Grpc.Client.Commands
{
    [Command("hello", Description = "Send Hello")]
    public class SendHello : SendBase
    {
        [Argument(0, Description = "Name")]
        public string Name { get; set; }

        protected Func<string, GreeterClient> ClientFunc;

        public SendHello(Func<string, GreeterClient> clientFunc) 
        {
            ClientFunc = clientFunc;
        }

        public async Task OnExecuteAsync()
        {
            var client = ClientFunc.Invoke(Parent.Channel);
            
            var reply = await client.SayHelloAsync(new HelloRequest { Name = Name });   
            Console.WriteLine($"Greeting: {reply.Message}"); 
        }
    }
}