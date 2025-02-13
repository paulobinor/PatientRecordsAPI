using Microsoft.AspNetCore.Mvc;
using PatientRecords.AppService.models;
using PatientRecords.Core.Interfaces;

namespace PatientRecords.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultationsController : ControllerBase
    {
        
        private readonly ILogger<ConsultationsController> _logger;
        private readonly IPatientService _patientService;

        public ConsultationsController(ILogger<ConsultationsController> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetConsultations([FromQuery] string startDate, string endDate, [FromQuery] string Id)
        {
            var searchResult =  await _patientService.GetConsultations(Convert.ToDateTime(startDate), Convert.ToDateTime(endDate), Id);
            var errors = new
            {
                ResponseCode = "00",
                ResponseDescription = "Success",
                Data = searchResult
            };
            return Ok();
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddNewConsultation(PatientRecords.Core.Dtos.CreateConsultationDto consultation)
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
            var newPatient = _patientService.CreateConsultation(consultation);
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

        [HttpPost("update")]
        public async Task<IActionResult> UpdateConsultation(PatientRecords.Core.Dtos.ConsultationDto consultation)
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
            var res = _patientService.UpdateConsultation(consultation);
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
                ResponseDescription = "Success",
                Date = res
            };
            return Ok(data);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteConsultation(PatientRecords.Core.Dtos.ConsultationDto consultation)
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
            consultation.IsDeleted = 1;
            var res = _patientService.UpdateConsultation(consultation);
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
                ResponseDescription = "Success",
                Date = res
            };
            return Ok(data);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetSingleConsultation([FromRoute] string Id)
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
            var res = _patientService.GetConsultation(Id);
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
