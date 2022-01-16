using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Intrefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task12.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase {
        private readonly ICrudService<Operation> _operationsService;

        public OperationsController(ICrudService<Operation> service) {
            _operationsService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operation>>> Get() {
            var operations = await _operationsService.GetAllItemsAsync();
            return operations.ToList();
        }

        // GET api/operations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operation>> Get(int id) {
            var operation = await _operationsService.GetAsync(id);
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
            await _operationsService.CreateAsync(operation);
            return Ok(operation);
        }

        // PUT api/operations/
        [HttpPut]
        public async Task<ActionResult<Operation>> Put(Operation operation) {
            if (operation == null) {
                return BadRequest();
            }
            await _operationsService.UpdateAsync(operation);
            return Ok(operation);
        }

        // DELETE api/operations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationType>> Delete(int id) {
            var operation = await _operationsService.GetAsync(id);
            if (operation == null) {
                return NotFound();
            }
            await _operationsService.DeleteAsync(id);
            return Ok(operation);
        }
    }
}
