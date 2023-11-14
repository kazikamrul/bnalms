using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SourceInformation;
using SchoolManagement.Application.Features.SourceInformations.Requests.Commands;
using SchoolManagement.Application.Features.SourceInformations.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SourceInformation)]
[ApiController]
[Authorize]
public class SourceInformationController : ControllerBase
{
    private readonly IMediator _mediator;

    public SourceInformationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-SourceInformations")]
    public async Task<ActionResult<List<SourceInformationDto>>> Get([FromQuery] QueryParams queryParams, int bookInformationId)
    {
        var SourceInformations = await _mediator.Send(new GetSourceInformationListRequest { QueryParams = queryParams, BookInformationId = bookInformationId});
        return Ok(SourceInformations);
    }

    

    [HttpGet]
    [Route("get-SourceInformationDetail/{id}")]
    public async Task<ActionResult<SourceInformationDto>> Get(int id)
    {
        var SourceInformation = await _mediator.Send(new GetSourceInformationDetailRequest { SourceInformationId = id });
        return Ok(SourceInformation);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-SourceInformation")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSourceInformationDto SourceInformation)
    {
        var command = new CreateSourceInformationCommand { SourceInformationDto = SourceInformation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-SourceInformation/{id}")]
    public async Task<ActionResult> Put([FromBody] SourceInformationDto SourceInformation)
    {
        var command = new UpdateSourceInformationCommand { SourceInformationDto = SourceInformation };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-SourceInformation/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSourceInformationCommand { SourceInformationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedSourceInformations")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedSourceInformation()
    {
        var selectedSourceInformation = await _mediator.Send(new GetSelectedSourceInformationRequest { });
        return Ok(selectedSourceInformation);
    }
}

