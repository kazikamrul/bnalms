using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Area;
using SchoolManagement.Application.Features.Areas.Requests.Commands;
using SchoolManagement.Application.Features.Areas.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Area)]
[ApiController]
[Authorize]
public class AreaController : ControllerBase
{
    private readonly IMediator _mediator;

    public AreaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Areas")]
    public async Task<ActionResult<List<AreaDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Areas = await _mediator.Send(new GetAreaListRequest { QueryParams = queryParams });
        return Ok(Areas);
    }

    

    [HttpGet]
    [Route("get-AreaDetail/{id}")]
    public async Task<ActionResult<AreaDto>> Get(int id)
    {
        var Area = await _mediator.Send(new GetAreaDetailRequest { AreaId = id });
        return Ok(Area);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Area")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAreaDto Area)
    {
        var command = new CreateAreaCommand { AreaDto = Area };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Area/{id}")]
    public async Task<ActionResult> Put([FromBody] AreaDto Area)
    {
        var command = new UpdateAreaCommand { AreaDto = Area };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Area/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAreaCommand { AreaId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedAreas")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedArea()
    {
        var selectedArea = await _mediator.Send(new GetSelectedAreaRequest { });
        return Ok(selectedArea);
    }
}

