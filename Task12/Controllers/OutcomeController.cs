using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Threading.Tasks;
using Services.DataTransferObjects;

namespace Task12.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OutcomeController : ControllerBase {
        private IOperationsService _service;

        public OutcomeController(IOperationsService service) {
            _service = service;
        }

        // GET api/outcome/Date
        [HttpGet, Route("Date")]
        public async Task<ActionResult<OutcomeDTO>> GetAsync(DateTime date) {
            return await _service.GetOutcomeAtDateAsync(date);
        }

        // GET api/outcome/Period
        [HttpGet, Route("Period")]
        public async Task<ActionResult<OutcomeDTO>> GetAsync(DateTime startDate, DateTime endDate) {
            return await _service.GetOutcomeAtPeriodAsync(startDate, endDate);
        }
    }
}
