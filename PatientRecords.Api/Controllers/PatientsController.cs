using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PatientRecords.AppService.models;
using PatientRecords.Core.Interfaces;
using System.Diagnostics.Tracing;

namespace PatientRecords.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        
        private readonly ILogger<PatientsController> _logger;
        private readonly IPatientService _patientService;

        public PatientsController(ILogger<PatientsController> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        [HttpGet(Name = "List")]
        public async Task<IActionResult> GetPatientList([FromQuery] string FirstName, [FromQuery] string LastName)
        {
            var searchResult = _patientService.PatientList(FirstName, LastName);
            var errors = new
            {
                ResponseCode = "00",
                ResponseDescription = "Success",
                Data = searchResult
            };
            return Ok();
        }

        [HttpPost(Name = "create")]
        public async Task<IActionResult> AddNewPatient(PatientRecords.Core.models.Patient patient)
        {
            if (!ModelState.IsValid)
            {
                var errors = new
                {
                    ResponseCode = "01",
                    ResponseDescription = "Falidation failed",
                        Data = string.Join("|", ModelState.Values.SelectMany(x => x.Errors))
                };
                return BadRequest(errors);
            }
            var newPatient = _patientService.CreatePatient(patient);
            if (newPatient == null)
            {
                var errors = new
                {
                    ResponseCode = "96",
                    ResponseDescription = "We encountered an error. Please try again later or contact support"
                };
                return StatusCode(500, errors);
            }
            return Ok(newPatient);
        }

        [HttpPost(Name = "update")]
        public async Task<IActionResult> UpdatePatient(PatientRecords.Core.models.Patient patient)
        {
            if (!ModelState.IsValid)
            {
                var errors = new
                {
                    ResponseCode = "01",
                    ResponseDescription = "Falidation failed",
                    Data = string.Join("|", ModelState.Values.SelectMany(x => x.Errors))
                };
                return BadRequest(errors);
            }
            var newPatient = _patientService.UpdatePatient(patient);
            if (newPatient == null)
            {
                var errors = new
                {
                    ResponseCode = "96",
                    ResponseDescription = "We encountered an error. Please try again later or contact support"
                };
                return StatusCode(500, errors);
            }
            return Ok(newPatient);
        }

        [HttpPost(Name = "Delete")]
        public async Task<IActionResult> DeletePatient(PatientRecords.Core.models.Patient patient)
        {
            if (!ModelState.IsValid)
            {
                var errors = new
                {
                    ResponseCode = "01",
                    ResponseDescription = "Falidation failed",
                    Data = string.Join("|", ModelState.Values.SelectMany(x => x.Errors))
                };
                return BadRequest(errors);
            }
            patient.IsDeleted = 1;
            var res = _patientService.UpdatePatient(patient);
            if (res == null)
            {
                var errors = new
                {
                    ResponseCode = "96",
                    ResponseDescription = "We encountered an error. Please try again later or contact support"
                };
                return StatusCode(500, errors);
            }
            var data = new
            {
                ResponseCode = "00",
                ResponseDescription = "We encountered an error. Please try again later or contact support"
            };
            return Ok(data);
        }

        [HttpPost("Get/{id}")]
        public async Task<IActionResult> GetSinglePatient([FromRoute] string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                var errors = new
                {
                    ResponseCode = "02",
                    ResponseDescription = "Validation failed! Id is required"
                };
                return BadRequest(errors);
            }
            var res = _patientService.GetSinglePatient(Id);
            if (res == null)
            {
                var errors = new
                {
                    ResponseCode = "25",
                    ResponseDescription = "No record found."
                };
                return NotFound(errors);
            }
            var data = new
            {
                ResponseCode = "00",
                ResponseDescription = "Success",
                Data = res
            };
            return Ok(data);
        }
    }
}
