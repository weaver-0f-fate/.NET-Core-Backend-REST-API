using Microsoft.AspNetCore.Mvc;
using Core.Models.Models;
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

        // GET api/outcome/5
        [HttpGet, Route("Date")]
        public async Task<ActionResult<OutcomeDTO>> Get(DateTime date) {
            var outcome = await _service.GetOperationsAtDateAsync(date);
            return outcome;
        }

        // GET api/outcome/5
        [HttpGet, Route("Period")]
        public async Task<ActionResult<OutcomeDTO>> Get(DateTime startDate, DateTime endDate) {
            var outcome = await _service.GetOperationsAtPeriodAsync(startDate, endDate);
            if (outcome == null) {
                return NotFound();
            }
            return outcome;
        }
    }
}
