using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.EventInfo;
using SchoolManagement.Application.Features.EventInfos.Requests.Commands;
using SchoolManagement.Application.Features.EventInfos.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.EventInfo)]
[ApiController]
[Authorize]
public class EventInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-EventInfos")]
    public async Task<ActionResult<List<EventInfoDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var EventInfos = await _mediator.Send(new GetEventInfoListRequest { QueryParams = queryParams });
        return Ok(EventInfos);
    }

    

    [HttpGet]
    [Route("get-EventInfoDetail/{id}")]
    public async Task<ActionResult<EventInfoDto>> Get(int id)
    {
        var EventInfo = await _mediator.Send(new GetEventInfoDetailRequest { EventInfoId = id });
        return Ok(EventInfo);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-EventInfo")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateEventInfoDto EventInfo)
    {
        var command = new CreateEventInfoCommand { EventInfoDto = EventInfo };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-EventInfo/{id}")]
    public async Task<ActionResult> Put([FromBody] EventInfoDto EventInfo)
    {
        var command = new UpdateEventInfoCommand { EventInfoDto = EventInfo };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-EventInfo/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteEventInfoCommand { EventInfoId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedEventInfos")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedEventInfo()
    {
        var selectedEventInfo = await _mediator.Send(new GetSelectedEventInfoRequest { });
        return Ok(selectedEventInfo);
    }
}

