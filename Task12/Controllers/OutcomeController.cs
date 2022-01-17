using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using Services.Intrefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<Outcome>> Get(string dateString) {
            DateTime.TryParse(dateString, out var date);
            var outcome = await _service.GetOperationsAtDateAsync(date);
            return outcome;
        }

        // GET api/outcome/5
        [HttpGet, Route("Period")]
        public async Task<ActionResult<Outcome>> Get(string startDateString, string endDateString) {
            DateTime.TryParse(startDateString, out var startDate);
            DateTime.TryParse(endDateString, out var endDate);


            var outcome = await _service.GetOperationsAtPeriodAsync(startDate, endDate);
            if (outcome == null) {
                return NotFound();
            }
            return outcome;
        }

    }
}
