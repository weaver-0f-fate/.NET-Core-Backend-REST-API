using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.DataTransferObjects.OperationDTOs;

namespace Task12.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase {
        private readonly IOperationsService _service;

        public OperationsController(IServiceWrapper service) {
            _service = service.OperationsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationDTO>>> Get() {
            var operations = await _service.GetAllItemsAsync();
            return operations.ToList();
        }

        // GET api/operations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationDTO>> Get(int id) {
            var operation = await _service.GetByIdAsync(id);
            if (operation == null) {
                return NotFound();
            }

            return new ObjectResult(operation);
        }

        // POST api/operations
        [HttpPost]
        public async Task<ActionResult<OperationDTO>> Post([FromBody]OperationForCreateDTO operation) {
            if (operation == null) {
                return BadRequest();
            }
            await _service.CreateOperationAsync(operation);
            return Ok();
        }

        // PUT api/operations/
        [HttpPut]
        public async Task<ActionResult<OperationDTO>> Put(int id, [FromBody]OperationForUpdateDTO updatedOperation) {
            if (updatedOperation == null) {
                return BadRequest("Operation object is null");
            }

            if (!await _service.ExistsAsync(id)) {
                return NotFound($"There is no Operation with id: {id}");
            }

            await _service.UpdateOperationAsync(id, updatedOperation);
            return Ok();
        }

        // DELETE api/operations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationDTO>> Delete(int id) {
            if (!await _service.ExistsAsync(id)) {
                return NotFound($"There is no Operation with id: {id}");
            }
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
