using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.DataTransferObjects.OperationDTOs;
using System;

namespace Task12.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase {
        private readonly IOperationsService _operationsService;

        public OperationsController(IOperationsService service) {
            _operationsService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationDTO>>> GetAsync() {
            var operations = await _operationsService.GetAllItemsAsync();
            return Ok(operations.ToList());
        }

        // GET api/operations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationDTO>> GetAsync(Guid id) {
            var operation = await _operationsService.GetByIdAsync(id);
            return Ok(operation);
        }

        // POST api/operations
        [HttpPost]
        public async Task<ActionResult<OperationDTO>> PostAsync([FromBody] OperationForCreateDTO newOperation) {
            var operation = await _operationsService.CreateOperationAsync(newOperation);
            return CreatedAtAction(nameof(GetAsync), new { id = operation.Id }, operation);
        }

        // PUT api/operations/
        [HttpPut("{id}")]
        public async Task<ActionResult<OperationDTO>> PutAsync(Guid id, [FromBody]OperationForUpdateDTO updatedOperation) {
            await _operationsService.UpdateOperationAsync(id, updatedOperation);
            return NoContent();
        }

        // DELETE api/operations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationDTO>> DeleteAsync(Guid id) {
            await _operationsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
