using Microsoft.AspNetCore.Mvc;

namespace Elixr2.Api.Controllers
{
    public class DevelopmentController
    {
        [HttpGet("dev/hello")]
        public string Hello() => "Hello world, from Elixr.Api";
    }
}