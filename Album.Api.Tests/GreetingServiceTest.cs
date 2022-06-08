using Album.Api.Services;
using System;
using System.Net;
using Xunit;

namespace Album.Api.Tests
{
    public class UnitTestGreetingService
    {
        [Fact]
        public void TestWithGivenName()
        {
            string name = "Usman";
            var greetingService = new GreetingService();
            Assert.Equal("Hello " + name + " from " + Dns.GetHostName() + " v2", greetingService.greet(name));
        }

        [Fact]
        public void TestWithGivenNull()
        {
            var greetingService = new GreetingService();
            Assert.Equal("Hello World from " + Dns.GetHostName() + " v2", greetingService.greet(null));
        }

        [Fact]
        public void TestWithGivenEmpty()
        {
            var greetingService = new GreetingService();
            Assert.Equal("Hello World from " + Dns.GetHostName() + " v2", greetingService.greet());
        }

        [Fact]
        public void TestWithGivenWhitespace()
        {
            var greetingService = new GreetingService();
            Assert.Equal("Hello World from " + Dns.GetHostName() + " v2", greetingService.greet(" "));
        }
    }
}
