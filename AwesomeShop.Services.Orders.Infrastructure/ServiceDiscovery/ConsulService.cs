using System;
using System.Linq;
using System.Threading.Tasks;
using Consul;

namespace AwesomeShop.Services.Orders.Infrastructure.ServiceDiscovery
{
    public class ConsulService : IServiceDiscoveryService
    {
        private readonly IConsulClient _consulClient;
        public ConsulService(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }
        public async Task<Uri> GetServiceUri(string serviceName, string requestUrl)
        {
            var allRegisteredServices = await _consulClient.Agent.Services();

            var registeredServices = allRegisteredServices.Response
                                            .Where(x => x.Value.Service == serviceName)
                                            .Select(x => x.Value)
                                            .ToList();

            var service = registeredServices.First();

            Console.WriteLine(service.Address);

            var uri =  $"http://{service.Address}:{service.Port}/{requestUrl}";

            return new Uri(uri);
        }
    }
}