using Microsoft.AspNetCore.Mvc;

namespace Logs.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {       
        private readonly ILogger<LogsController> _logger;

        public LogsController(ILogger<LogsController> logger) => _logger = logger;

        [HttpGet]
        [Route("info")]
        public ActionResult GetInfo()
        {
            _logger.LogInformation("This is an information log");
            return Ok("Information log has been written");
        }

        [HttpGet]
        [Route("warning")]
        public ActionResult GetWarning()
        {
            _logger.LogWarning("This is a warning log");
            return Ok("Warning log has been written");
        }

        [HttpGet]
        [Route("error")]
        public ActionResult GetError()
        {
            _logger.LogError("This is an error log");
            return Ok("Error log has been written");
        }

        [HttpGet]
        [Route("exception")]
        public ActionResult GetException() => throw new Exception("This is an exception");
    }
}
