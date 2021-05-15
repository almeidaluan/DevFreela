using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Commands.UserCreate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"{id}");
        }

        [HttpPost]
        public async Task<IActionResult> CreateUSer([FromBody] List<UserCreateCommand> createUserCommand)
        {
            
           if(!ModelState.IsValid){
               var messages = ModelState
               .SelectMany( ms => ms.Value.Errors)
               .Select(e => e.ErrorMessage)
               .ToList();
               return BadRequest(messages);
           }

            var id = await _mediator.Send(createUserCommand);
            return CreatedAtAction(nameof(GetById), new { id = id }, createUserCommand);
        }

    }

    
}