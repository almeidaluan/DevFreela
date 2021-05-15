using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.SaveComment;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetByIdProject;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {

        private readonly OpeningTime _openingTime;

        private readonly IProjectService projectService;

        private readonly IMediator _mediator;

        public ProjectController(IOptions<OpeningTime> openingTime,IProjectService projectService,IMediator mediator)
        {
            _openingTime = openingTime.Value;
            this.projectService = projectService;
            this._mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetProjectsAsync(string query)
        {
            var result = new GetAllProjectsQueries(query);
            var projects = await _mediator.Send(result);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var projectById = new GetByIdProjectQueries(id);

            var project = await _mediator.Send(projectById);

            if(project == null){
                return NotFound();
            }
            return Ok(project);
        }
        [HttpPost]
        public async Task<IActionResult> SaveProject([FromBody] CreateProjectCommand command)
        {

            if (command.Title.Length < 5)
            {
                return BadRequest("Ocorreu um erro");
                
            }
            //var id = projectService.Create(newProjectInputModel);
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> SaveComments(int id, [FromBody] SaveCommentCommand saveCommentCommand)
        {

            if (saveCommentCommand.Content.Length < 5)
            {
                return BadRequest("Ocorreu um erro");
                
            }
            await _mediator.Send(saveCommentCommand);
            return NoContent();//CreatedAtAction(nameof(GetById), new { id = createCommentInputModel.Id }, createCommentInputModel);
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var startProject = new StartProjectCommand(id);
            await _mediator.Send(startProject);
            
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var finishProject = new FinishProjectCommand(id);
            await _mediator.Send(finishProject);
            return NoContent();
        }
    }

}