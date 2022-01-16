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
    public class OperationTypesController : ControllerBase {
        OperationsContext _dbContext;

        public OperationTypesController(OperationsContext context) {
            _dbContext = context;

            if (!_dbContext.OperationTypes.Any()) {
                _dbContext.OperationTypes.Add(new OperationType { Name = "Purchase" });
                _dbContext.OperationTypes.Add(new OperationType { Name = "Salary" });
                _dbContext.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationType>>> Get() {
            return await _dbContext.OperationTypes.ToListAsync();
        }

        // GET api/operationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationType>> Get(int id) {
            var operationType = await _dbContext.OperationTypes.FirstOrDefaultAsync(type => type.Id == id);
            if (operationType == null) {
                return NotFound();
            }

            return new ObjectResult(operationType);
        }

        // POST api/operationTypes
        [HttpPost]
        public async Task<ActionResult<OperationType>> Post(OperationType operationType) {
            if (operationType == null) {
                return BadRequest();
            }

            _dbContext.OperationTypes.Add(operationType);
            await _dbContext.SaveChangesAsync();
            return Ok(operationType);
        }

        // PUT api/operationTypes/
        [HttpPut]
        public async Task<ActionResult<OperationType>> Put(OperationType operationType) {
            if (operationType == null) {
                return BadRequest();
            }
            if (!_dbContext.OperationTypes.Any(x => x.Id == operationType.Id)) {
                return NotFound();
            }

            _dbContext.Update(operationType);
            await _dbContext.SaveChangesAsync();
            return Ok(operationType);
        }

        // DELETE api/operationTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationType>> Delete(int id) {
            var operationType = _dbContext.OperationTypes.FirstOrDefault(x => x.Id == id);
            if (operationType == null) {
                return NotFound();
            }
            _dbContext.OperationTypes.Remove(operationType);
            await _dbContext.SaveChangesAsync();
            return Ok(operationType);
        }

    }
}
