using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.AuthorInformation;
using SchoolManagement.Application.Features.AuthorInformations.Requests.Commands;
using SchoolManagement.Application.Features.AuthorInformations.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.AuthorInformation)]
[ApiController]
[Authorize]
public class AuthorInformationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorInformationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-AuthorInformations")]
    public async Task<ActionResult<List<AuthorInformationDto>>> Get([FromQuery] QueryParams queryParams, int bookInformationId)
    {
        var AuthorInformations = await _mediator.Send(new GetAuthorInformationListRequest { QueryParams = queryParams, BookInformationId = bookInformationId });
        return Ok(AuthorInformations);
    }

    

    [HttpGet]
    [Route("get-AuthorInformationDetail/{id}")]
    public async Task<ActionResult<AuthorInformationDto>> Get(int id)
    {
        var AuthorInformation = await _mediator.Send(new GetAuthorInformationDetailRequest { AuthorInformationId = id });
        return Ok(AuthorInformation);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-AuthorInformation")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAuthorInformationDto AuthorInformation)
    {
        var command = new CreateAuthorInformationCommand { AuthorInformationDto = AuthorInformation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-AuthorInformation/{id}")]
    public async Task<ActionResult> Put([FromBody] AuthorInformationDto AuthorInformation)
    {
        var command = new UpdateAuthorInformationCommand { AuthorInformationDto = AuthorInformation };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-AuthorInformation/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAuthorInformationCommand { AuthorInformationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedAuthorInformations")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedAuthorInformation()
    {
        var selectedAuthorInformation = await _mediator.Send(new GetSelectedAuthorInformationRequest { });
        return Ok(selectedAuthorInformation);
    }
}

