using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Services;
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

        [HttpGet("List")]
        public async Task<IActionResult> GetPatientList([FromQuery] string FirstName = null, [FromQuery] string LastName = null)
        {
            var searchResult = await _patientService.PatientList(FirstName, LastName);
            //var data = new
            //{
            //    ResponseCode = "00",
            //    ResponseDescription = "Success",
            //    Data = searchResult
            //};
            return Ok(searchResult);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddNewPatient(PatientRecords.Core.Dtos.CreatePatientDto createPatientDto)
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
            var newPatient = await _patientService.CreatePatient(createPatientDto);
            if (newPatient == null)
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
                ResponseDescription = "Success",
                Data = newPatient
            };
            return Ok(data);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdatePatient(PatientRecords.Core.Dtos.PatientDto patient)
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
            var updatePatient = await _patientService.UpdatePatient(patient);
            if (updatePatient == null)
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
                ResponseDescription = "Success",
                Data = updatePatient
            };
            return Ok(data);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeletePatient(PatientRecords.Core.Dtos.PatientDto patient)
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
                ResponseDescription = "Success"
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
