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
        private readonly IOperationsService _operationsService;

        public OperationsController(IOperationsService service) {
            _operationsService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationDTO>>> Get() {
            var operations = await _operationsService.GetAllItemsAsync();
            return operations.ToList();
        }

        // GET api/operations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationDTO>> Get(int id) {
            var operation = await _operationsService.GetByIdAsync(id);
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
            await _operationsService.CreateOperationAsync(operation);
            return Ok(operation);
        }

        // PUT api/operations/
        [HttpPut]
        public async Task<ActionResult<OperationDTO>> Put(int id, [FromBody]OperationForUpdateDTO operation) {
            if (operation == null) {
                return BadRequest();
            }
            await _operationsService.UpdateOperationAsync(operation);
            return Ok(operation);
        }

        // DELETE api/operations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationDTO>> Delete(int id) {
            var operation = _operationsService.GetByIdAsync(id);
            if (operation == null) {
                return NotFound();
            }
            await _operationsService.DeleteAsync(id);
            return Ok(operation);
        }
    }
}
