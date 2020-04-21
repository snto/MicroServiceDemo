using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Microsoft.Extensions.Configuration;

namespace API.Utils
{
    public static class ConsulHelper
    {
        public static void ConsulRegister(this IConfiguration Configuration)
        {
            ConsulClient client = new ConsulClient(c =>
            {
                c.Address= new Uri("http://localhost:8500/");
                c.Datacenter = "dc1";
            });
            client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID="service" +Guid.NewGuid(),
                Name = "sickfoxService",//组名称
                Address = "127.0.0.1",//公网ip
                Port = 5726,
                Tags = null
            });
        }
    }
}
