using Album.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Api.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet("/api/hello")]
        public IActionResult Index(string? name = null)
        {
            var greetingService = new GreetingService();
            var result = greetingService.greet(name);
            return Ok(result);
        }
    }
}
