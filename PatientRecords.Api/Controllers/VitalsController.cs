using Microsoft.AspNetCore.Mvc;
using PatientRecords.AppService.models;
using PatientRecords.Core.Interfaces;

namespace PatientRecords.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VitalsController : ControllerBase
    {
        
        private readonly ILogger<VitalsController> _logger;
        private readonly IPatientService _patientService;

        public VitalsController(ILogger<VitalsController> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        [HttpGet(Name = "List")]
        public async Task<IActionResult> GetVitals([FromQuery] string startDate, string endDate, [FromQuery] string Id)
        {
            var searchResult =  await _patientService.GetPatientVitals(Convert.ToDateTime(startDate), Convert.ToDateTime(endDate), Id);
            var errors = new
            {
                ResponseCode = "00",
                ResponseDescription = "Success",
                Data = searchResult
            };
            return Ok();
        }

        [HttpPost(Name = "create")]
        public async Task<IActionResult> AddNewVitals(PatientRecords.Core.models.VitalSign vitalSign)
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
            var res = _patientService.CreateVitals(vitalSign);
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
                Data = res
            };
            return Ok(data);
        }

        [HttpPost(Name = "update")]
        public async Task<IActionResult> UpdateVitals(PatientRecords.Core.models.VitalSign vitalSign)
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
            var res = _patientService.UpdateVitals(vitalSign);
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

        [HttpPost(Name = "Delete")]
        public async Task<IActionResult> DeleteVitals(PatientRecords.Core.models.VitalSign vitalSign)
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
            vitalSign.IsDeleted = 1;
            var res = _patientService.UpdateVitals(vitalSign);
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

        [HttpPost("Get/{id}")]
        public async Task<IActionResult> GetSingleVitals([FromRoute] string Id)
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
            var res = _patientService.GetSingleVitals(Id);
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
