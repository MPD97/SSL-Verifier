using System.Threading.Tasks;
using Convey;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace SSL_Verifier.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await CreateWebHostBuilder(args)
                .Build()
                .RunAsync();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services
                    .AddConvey()
                    .AddWebApi()
                    .Build())
                .Configure(app => app
                    .UseDispatcherEndpoints(endpoints => endpoints
                        .Get(".well-known/pki-validation/6D646E510F39C567713A207D604DDEC5.txt", ctx => ctx.Response.WriteAsync(@"B1F268764D840D2932C3F40D4AA9169C4BE52CF547D1D27586FDE6BD9BBAFF2A
comodoca.com
aabefd1ba2b17a8"))));
    }
}