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
    public class OperationsController : ControllerBase {
        OperationsContext _dbContext;

        public OperationsController(OperationsContext context) {
            _dbContext = context;

            if (!_dbContext.Operations.Any()) {
                _dbContext.Operations.Add(new Operation { 
                    OperationTypeId = 1,
                    Name = "Home Purchase",
                    Date = DateTime.Now,
                    Amount = -50000
                });
                _dbContext.Operations.Add(new Operation { 
                    OperationTypeId = 2,
                    Name = "Salary",
                    Date = DateTime.Now.AddDays(-1),
                    Amount = 4000
                });
                _dbContext.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operation>>> Get() {
            return await _dbContext.Operations.ToListAsync();
        }

        // GET api/operations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operation>> Get(int id) {
            var operation = await _dbContext.Operations.FirstOrDefaultAsync(type => type.Id == id);
            if (operation == null) {
                return NotFound();
            }

            return new ObjectResult(operation);
        }

        // POST api/operations
        [HttpPost]
        public async Task<ActionResult<Operation>> Post(Operation operation) {
            if (operation == null) {
                return BadRequest();
            }

            _dbContext.Operations.Add(operation);
            await _dbContext.SaveChangesAsync();
            return Ok(operation);
        }

        // PUT api/operations/
        [HttpPut]
        public async Task<ActionResult<Operation>> Put(Operation operation) {
            if (operation == null) {
                return BadRequest();
            }
            if (!_dbContext.Operations.Any(x => x.Id == operation.Id)) {
                return NotFound();
            }

            _dbContext.Update(operation);
            await _dbContext.SaveChangesAsync();
            return Ok(operation);
        }

        // DELETE api/operations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationType>> Delete(int id) {
            var operation = _dbContext.Operations.FirstOrDefault(x => x.Id == id);
            if (operation == null) {
                return NotFound();
            }
            _dbContext.Operations.Remove(operation);
            await _dbContext.SaveChangesAsync();
            return Ok(operation);
        }

    }
}
