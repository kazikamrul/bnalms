using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.InventoryTypes;
using SchoolManagement.Application.Features.InventoryTypes.Requests.Commands;
using SchoolManagement.Application.Features.InventoryTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.InventoryTypes)]
[ApiController]
[Authorize]
public class InventoryTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoryTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-InventoryTypes")]
    public async Task<ActionResult<List<InventoryTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var InventoryTypes = await _mediator.Send(new GetInventoryTypeListRequest { QueryParams = queryParams });
        return Ok(InventoryTypes);
    }

    

    [HttpGet]
    [Route("get-InventoryTypeDetail/{id}")]
    public async Task<ActionResult<InventoryTypeDto>> Get(int id)
    {
        var InventoryType = await _mediator.Send(new GetInventoryTypeDetailRequest { InventoryTypeId = id });
        return Ok(InventoryType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-InventoryType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateInventoryTypeDto InventoryType)
    {
        var command = new CreateInventoryTypeCommand { InventoryTypeDto = InventoryType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-InventoryType/{id}")]
    public async Task<ActionResult> Put([FromBody] InventoryTypeDto InventoryType)
    {
        var command = new UpdateInventoryTypeCommand { InventoryTypeDto = InventoryType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-InventoryType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteInventoryTypeCommand { InventoryTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedInventoryTypes")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedInventoryType()
    {
        var selectedInventoryType = await _mediator.Send(new GetSelectedInventoryTypeRequest { });
        return Ok(selectedInventoryType);
    }
}

