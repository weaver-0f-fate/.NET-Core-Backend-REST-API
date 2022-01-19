using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.DataTransferObjects;
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
        public async Task<ActionResult<OperationTypeDTO>> Post(OperationTypeDTO operationType) {
            if (operationType == null) {
                return BadRequest();
            }

            await _operationTypesService.CreateAsync(operationType);
            return Ok(operationType);
        }

        // PUT api/operationTypes/
        [HttpPut]
        public async Task<ActionResult<OperationTypeDTO>> Put(OperationTypeDTO operationType) {
            if (operationType == null) {
                return BadRequest();
            }
            await _operationTypesService.UpdateAsync(operationType);
            return Ok(operationType);
        }

        // DELETE api/operationTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationTypeDTO>> Delete(int id) {
            var operationType = _operationTypesService.GetByIdAsync(id);
            if (operationType == null) {
                return NotFound();
            }
            await _operationTypesService.DeleteAsync(id);
            return Ok(operationType);
        }

    }
}
