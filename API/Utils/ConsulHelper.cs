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
        public static void ConsulRegister(this IConfiguration configuration)
        {
            ConsulClient client = new ConsulClient(c =>
            {
                c.Address= new Uri("http://localhost:8500/");
                c.Datacenter = "dc1";
            });
            string ip = configuration["ip"];
            int port = int.Parse(configuration["port"]);
            client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID="service" +Guid.NewGuid(),
                Name = "sickfoxService",//组名称
                Address = ip,//公网ip
                Port = port,
                Tags = null,
                Check = new AgentServiceCheck()
                {
                    Interval = TimeSpan.FromSeconds(12),
                    HTTP = "http://{ip}:{port}/"
                }
            });
            //命令行参数获取
        }
    }
}
