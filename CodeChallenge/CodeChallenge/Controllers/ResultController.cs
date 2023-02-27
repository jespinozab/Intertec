using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Controllers
{
    [ApiController] 
    [Route("[controller]")] 
    public class ResultController : ControllerBase
    {
        private readonly ILogger<ResultController> _logger; // This is for logging implementation, not covered in this code challenge
        private readonly IService _service; // This private field holds a service object that will be used to process input strings

        public ResultController(ILogger<ResultController> logger, IService service)
        {
            _logger = logger; 
            _service = service; 
        }

        [HttpGet(Name = "GetResult")] 
        public string Get([FromQuery] string input) // This method takes a string input parameter that is received as a query string parameter, and returns a string result
        {
            return _service.GetResult(input); 
        }

    }
}
