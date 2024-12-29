using Microsoft.AspNetCore.Mvc;

namespace OptionSettingPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonServiceWithOptions personServiceWithOptions;
        private readonly IPersonServiceWithOptionsSnapshot personServiceWithOptionsSnapshot;
        private readonly IPersonServiceWithOptionsMonitor personServiceWithOptionsMonitor;

        public PersonController(IPersonServiceWithOptions personServiceWithOptions, 
            IPersonServiceWithOptionsSnapshot personServiceWithOptionsSnapshot, 
            IPersonServiceWithOptionsMonitor personServiceWithOptionsMonitor)
        {
            this.personServiceWithOptions = personServiceWithOptions;
            this.personServiceWithOptionsSnapshot = personServiceWithOptionsSnapshot;
            this.personServiceWithOptionsMonitor = personServiceWithOptionsMonitor;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var ps1 = personServiceWithOptions.Get();
            var ps2 = personServiceWithOptionsSnapshot.Get();
            var ps3 = personServiceWithOptionsMonitor.Get();

            return Ok();
        }
    }
}
