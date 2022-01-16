using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task12.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OutcomeController : ControllerBase {
        OperationsContext _dbContext;

        public OutcomeController(OperationsContext context) {
            _dbContext = context;
        }

        [HttpGet, Route("Date")]
        public async Task<ActionResult<IEnumerable<Operation>>> Get(string dateString) {
            DateTime.TryParse(dateString, out var date);
            return await _dbContext.Operations.Where(x => x.Date.Date == date.Date).ToListAsync();
        }

        // GET api/operations/5
        [HttpGet, Route("Period")]
        public async Task<ActionResult<IEnumerable<Operation>>> Get(string startDateString, string endDateString) {
            DateTime.TryParse(startDateString, out var startDate);
            DateTime.TryParse(endDateString, out var endDate);
            var operations = _dbContext.Operations
                .Where(operation => 
                operation.Date >= startDate && 
                operation.Date <= endDate);
            if (operations == null) {
                return NotFound();
            }

            return await operations.ToListAsync();
        }

    }
}
