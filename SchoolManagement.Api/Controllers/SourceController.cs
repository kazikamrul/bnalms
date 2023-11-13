using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Source;
using SchoolManagement.Application.Features.Sources.Requests.Commands;
using SchoolManagement.Application.Features.Sources.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Source)]
[ApiController]
[Authorize]
public class SourceController : ControllerBase
{
    private readonly IMediator _mediator;

    public SourceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Sources")]
    public async Task<ActionResult<List<SourceDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Sources = await _mediator.Send(new GetSourceListRequest { QueryParams = queryParams });
        return Ok(Sources);
    }

    

    [HttpGet]
    [Route("get-SourceDetail/{id}")]
    public async Task<ActionResult<SourceDto>> Get(int id)
    {
        var Source = await _mediator.Send(new GetSourceDetailRequest { SourceId = id });
        return Ok(Source);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Source")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSourceDto Source)
    {
        var command = new CreateSourceCommand { SourceDto = Source };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Source/{id}")]
    public async Task<ActionResult> Put([FromBody] SourceDto Source)
    {
        var command = new UpdateSourceCommand { SourceDto = Source };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Source/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSourceCommand { SourceId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedSources")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedSource()
    {
        var selectedSource = await _mediator.Send(new GetSelectedSourceRequest { });
        return Ok(selectedSource);
    }
}

