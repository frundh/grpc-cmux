using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Grpc.Core;
using Grpc.Proto;
using Microsoft.Extensions.Logging;
using static Grpc.Proto.Greeter;

namespace Grpc.Server.Controllers
{
    [Route("api/greet")]
    [ApiController]
    public class GreeterController : ControllerBase
    {
        protected GreeterClient Client;

        public GreeterController(GreeterClient client)
        {
            Client = client;
        }

        [HttpPost]
        public async Task<ActionResult<HelloReply>> Post([FromBody] HelloRequest request)
        {
            var reply = await Client.SayHelloAsync(request);
            return reply;
        }
    }
}