using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.DataTransferObjects.OperationTypesDTOs;
using Services.Interfaces;

namespace Task12.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OperationTypesController : ControllerBase {
        IOperationTypesService _operationTypesService;

        public OperationTypesController(IOperationTypesService service) {
            _operationTypesService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationTypeDTO>>> Get() {
            var operationTypes =  await _operationTypesService.GetAllItemsAsync();
            return operationTypes.ToList();
        }

        // GET api/operationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationTypeDTO>> Get(int id) {
            var operationType = await _operationTypesService.GetByIdAsync(id);
            if (operationType == null) {
                return NotFound();
            }

            return new ObjectResult(operationType);
        }

        // POST api/operationTypes
        [HttpPost]
        public async Task<ActionResult<OperationTypeDTO>> Post([FromBody]OperationTypeForCreateDTO operationType) {
            if (operationType == null) {
                return BadRequest();
            }

            await _operationTypesService.CreateOperationTypeAsync(operationType);
            return Ok(operationType);
        }

        // PUT api/operationTypes/
        [HttpPut]
        public async Task<ActionResult<OperationTypeDTO>> Put(int id, [FromBody]OperationTypeForUpdateDTO updatedOperationType) {
            if (updatedOperationType == null) {
                return BadRequest("OperationType object is null");
            }
            var operationType = await _operationTypesService.GetByIdAsync(id);
            if(operationType is null) {
                return NotFound($"There is no Operation Type with id: {id}");
            }

            await _operationTypesService.UpdateOperationTypeAsync(id, updatedOperationType);
            return Ok(updatedOperationType);
        }

        // DELETE api/operationTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationTypeDTO>> Delete(int id) {
            var operationType = await _operationTypesService.GetByIdAsync(id);
            if (operationType == null) {
                return NotFound();
            }
            await _operationTypesService.DeleteAsync(operationType);
            return Ok(operationType);
        }

    }
}
