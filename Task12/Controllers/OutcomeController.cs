using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Threading.Tasks;
using Services.DataTransferObjects;

namespace Task12.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OutcomeController : ControllerBase {
        private IOperationsService _operationsService;

        public OutcomeController(IOperationsService service) {
            _operationsService = service;
        }

        // GET api/outcome/Date
        [HttpGet, Route("Date")]
        public async Task<ActionResult<OutcomeDTO>> GetAsync(DateTime date) {
            var outcome = await _operationsService.GetOutcomeAtDateAsync(date);
            return Ok(outcome);
        }

        // GET api/outcome/Period
        [HttpGet, Route("Period")]
        public async Task<ActionResult<OutcomeDTO>> GetAsync(DateTime startDate, DateTime endDate) {
            var outcome = await _operationsService.GetOutcomeAtPeriodAsync(startDate, endDate);
            return Ok(outcome);
        }
    }
}
