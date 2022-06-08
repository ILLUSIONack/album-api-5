using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Album.Api.Services
{
    public class GreetingService
    {
        public GreetingService() { }

        public string greet(string? name = null)
        {
            return (String.IsNullOrWhiteSpace(name) || name == "") ?  "Hello World from " + Dns.GetHostName() + " v2": "Hello " + name + " from " + Dns.GetHostName() + " v2";
        }
    }
}
