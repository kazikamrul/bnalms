using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SecurityQuestion;
using SchoolManagement.Application.Features.SecurityQuestions.Requests.Commands;
using SchoolManagement.Application.Features.SecurityQuestions.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SecurityQuestion)]
[ApiController]
[Authorize]
public class SecurityQuestionController : ControllerBase
{
    private readonly IMediator _mediator;

    public SecurityQuestionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-SecurityQuestions")]
    public async Task<ActionResult<List<SecurityQuestionDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SecurityQuestions = await _mediator.Send(new GetSecurityQuestionListRequest { QueryParams = queryParams });
        return Ok(SecurityQuestions);
    }

    

    [HttpGet]
    [Route("get-SecurityQuestionDetail/{id}")]
    public async Task<ActionResult<SecurityQuestionDto>> Get(int id)
    {
        var SecurityQuestion = await _mediator.Send(new GetSecurityQuestionDetailRequest { SecurityQuestionId = id });
        return Ok(SecurityQuestion);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-SecurityQuestion")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSecurityQuestionDto SecurityQuestion)
    {
        var command = new CreateSecurityQuestionCommand { SecurityQuestionDto = SecurityQuestion };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-SecurityQuestion/{id}")]
    public async Task<ActionResult> Put([FromBody] SecurityQuestionDto SecurityQuestion)
    {
        var command = new UpdateSecurityQuestionCommand { SecurityQuestionDto = SecurityQuestion };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-SecurityQuestion/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSecurityQuestionCommand { SecurityQuestionId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedSecurityQuestions")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedSecurityQuestion()
    {
        var selectedSecurityQuestion = await _mediator.Send(new GetSelectedSecurityQuestionRequest { });
        return Ok(selectedSecurityQuestion);
    }
}

