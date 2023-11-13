using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ShelfInfo;
using SchoolManagement.Application.Features.ShelfInfos.Requests.Commands;
using SchoolManagement.Application.Features.ShelfInfos.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ShelfInfo)]
[ApiController]
[Authorize]
public class ShelfInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShelfInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ShelfInfos")]
    public async Task<ActionResult<List<ShelfInfoDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ShelfInfos = await _mediator.Send(new GetShelfInfoListRequest { QueryParams = queryParams });
        return Ok(ShelfInfos);
    }

    

    [HttpGet]
    [Route("get-ShelfInfoDetail/{id}")]
    public async Task<ActionResult<ShelfInfoDto>> Get(int id)
    {
        var ShelfInfo = await _mediator.Send(new GetShelfInfoDetailRequest { ShelfInfoId = id });
        return Ok(ShelfInfo);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ShelfInfo")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateShelfInfoDto ShelfInfo)
    {
        var command = new CreateShelfInfoCommand { ShelfInfoDto = ShelfInfo };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-ShelfInfo/{id}")]
    public async Task<ActionResult> Put([FromBody] ShelfInfoDto ShelfInfo)
    {
        var command = new UpdateShelfInfoCommand { ShelfInfoDto = ShelfInfo };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ShelfInfo/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteShelfInfoCommand { ShelfInfoId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedShelfInfos")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedShelfInfo()
    {
        var selectedShelfInfo = await _mediator.Send(new GetSelectedShelfInfoRequest { });
        return Ok(selectedShelfInfo);
    }
}

