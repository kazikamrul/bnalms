using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.RowInfo;
using SchoolManagement.Application.Features.RowInfos.Requests.Commands;
using SchoolManagement.Application.Features.RowInfos.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.RowInfo)]
[ApiController]
[Authorize]
public class RowInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public RowInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-RowInfos")]
    public async Task<ActionResult<List<RowInfoDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var RowInfos = await _mediator.Send(new GetRowInfoListRequest { QueryParams = queryParams });
        return Ok(RowInfos);
    }

    

    [HttpGet]
    [Route("get-RowInfoDetail/{id}")]
    public async Task<ActionResult<RowInfoDto>> Get(int id)
    {
        var RowInfo = await _mediator.Send(new GetRowInfoDetailRequest { RowInfoId = id });
        return Ok(RowInfo);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-RowInfo")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateRowInfoDto RowInfo)
    {
        var command = new CreateRowInfoCommand { RowInfoDto = RowInfo };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-RowInfo/{id}")]
    public async Task<ActionResult> Put([FromBody] RowInfoDto RowInfo)
    {
        var command = new UpdateRowInfoCommand { RowInfoDto = RowInfo };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-RowInfo/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteRowInfoCommand { RowInfoId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedRowInfos")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedRowInfo()
    {
        var selectedRowInfo = await _mediator.Send(new GetSelectedRowInfoRequest { });
        return Ok(selectedRowInfo);
    }
    [HttpGet]
    [Route("get-selectedRowNameByShelfInfo")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedRowNameByShelfInfo(int shelfInfoId)
    {
        var countryByCountryGroup = await _mediator.Send(new GetRowNameByShelfInfoIdRequest { ShelfInfoId = shelfInfoId });
        return Ok(countryByCountryGroup);
    }
}

