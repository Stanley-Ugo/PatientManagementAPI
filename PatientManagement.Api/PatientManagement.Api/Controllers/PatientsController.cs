using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Application.Commands;
using PatientManagement.Application.Queries;
using PatientManagement.Core.Entities;

namespace PatientManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetAllPatients()
        {
            var query = new GetAllPatientsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var query = new GetPatientByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePatient(CreatePatientCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPatient), new { id = result }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, UpdatePatientCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeletePatient(int id)
        {
            await _mediator.Send(new SoftDeletePatientCommand { Id = id });
            return NoContent();
        }
    }
}
