using Microsoft.AspNetCore.Mvc;

namespace DockerTest.Server.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {

        [HttpGet("[action]")]
        public string Test()
        {
            return "Hello World";
        }
    }
}
