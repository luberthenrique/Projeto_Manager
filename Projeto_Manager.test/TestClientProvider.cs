using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Projeto_Manager.api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Projeto_Manager.test
{
    public class TestClientProvider
    {
        public HttpClient client { get; private set; }
        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            client = server.CreateClient();
        }
    }
}
