using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.DataTransferObjects.OperationTypesDTOs;
using Services.Interfaces;
using System;

namespace Task12.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OperationTypesController : ControllerBase {
        IOperationTypesService _operationTypesService;

        public OperationTypesController(IServiceWrapper service) {
            _operationTypesService = service.OperationTypesService;
        }

        // GET api/operationTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationTypeDTO>>> GetAsync() {
            var operationTypes =  await _operationTypesService.GetAllItemsAsync();
            return new ObjectResult(operationTypes.ToList());
        }

        // GET api/operationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationTypeDTO>> GetAsync(Guid id) {
            var operationType = await _operationTypesService.GetByIdAsync(id);
            if (operationType == null) {
                return NotFound();
            }
            return new ObjectResult(operationType);
        }

        // POST api/operationTypes
        [HttpPost]
        public async Task<ActionResult<OperationTypeDTO>> PostAsync([FromBody]OperationTypeForCreateDTO operationType) {
            if (operationType == null) {
                return BadRequest();
            }
            var response = await _operationTypesService.CreateOperationTypeAsync(operationType);
            return Ok(response);
        }

        // PUT api/operationTypes/
        [HttpPut]
        public async Task<ActionResult<OperationTypeDTO>> PutAsync(Guid id, [FromBody]OperationTypeForUpdateDTO updatedOperationType) {
            if (updatedOperationType is null) {
                return BadRequest("OperationType object is null");
            }

            if (!await _operationTypesService.ExistsAsync(id)) {
                return NotFound($"There is no Operation Type with id: {id}");
            }

            var response = await _operationTypesService.UpdateOperationTypeAsync(id, updatedOperationType);
            return Ok(response);
        }

        // DELETE api/operationTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationTypeDTO>> DeleteAsync(Guid id) {
            if(! await _operationTypesService.ExistsAsync(id)) {
                return NotFound($"There is no Operation Type with id: {id}");
            }
            await _operationTypesService.DeleteAsync(id);
            return Ok();
        }

    }
}
