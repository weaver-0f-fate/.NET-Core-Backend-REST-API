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
        private readonly IOperationsService _service;

        public OperationsController(IServiceWrapper service) {
            _service = service.OperationsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationDTO>>> GetAsync() {
            var operations = await _service.GetAllItemsAsync();
            return operations.ToList();
        }

        // GET api/operations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationDTO>> GetAsync(Guid id) {
            var operation = await _service.GetByIdAsync(id);
            if (operation == null) {
                return NotFound();
            }

            return new ObjectResult(operation);
        }

        // POST api/operations
        [HttpPost]
        public async Task<ActionResult<OperationDTO>> PostAsync([FromBody]OperationForCreateDTO operation) {
            if (operation == null) {
                return BadRequest();
            }
            var response = await _service.CreateOperationAsync(operation);
            return Ok(response);
        }

        // PUT api/operations/
        [HttpPut]
        public async Task<ActionResult<OperationDTO>> PutAsync(Guid id, [FromBody]OperationForUpdateDTO updatedOperation) {
            if (updatedOperation == null) {
                return BadRequest("Operation object is null");
            }

            if (!await _service.ExistsAsync(id)) {
                return NotFound($"There is no Operation with id: {id}");
            }

            var response = await _service.UpdateOperationAsync(id, updatedOperation);
            return Ok(response);
        }

        // DELETE api/operations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationDTO>> DeleteAsync(Guid id) {
            if (!await _service.ExistsAsync(id)) {
                return NotFound($"There is no Operation with id: {id}");
            }
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
