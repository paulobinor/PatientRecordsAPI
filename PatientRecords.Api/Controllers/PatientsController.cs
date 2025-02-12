using Microsoft.AspNetCore.Mvc;
using PatientRecords.AppService.models;

namespace PatientRecords.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientsController : ControllerBase
    {
        
        private readonly ILogger<PatientsController> _logger;

        public PatientsController(ILogger<PatientsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "List")]
        public IEnumerable<WeatherForecast> GetPatientList([FromQuery] SearchFilterModel searchFilter)
        {
           
        }

        [HttpPost(Name = "create")]
        public IEnumerable<WeatherForecast> AddNewPatient(PatientRecords.Core.models.Patient patient)
        {
           
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
