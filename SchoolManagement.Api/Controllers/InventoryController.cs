using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Inventorys;
using SchoolManagement.Application.Features.Inventorys.Requests.Commands;
using SchoolManagement.Application.Features.Inventorys.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Inventory)]
[ApiController]
[Authorize]
public class InventoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Inventorys")]
    public async Task<ActionResult<List<InventoryDto>>> Get([FromQuery] QueryParams queryParams,int baseSchoolNameId, int inventoryTypeId)
    {
        var Inventorys = await _mediator.Send(new GetInventoryListRequest { QueryParams = queryParams,BaseSchoolNameId =baseSchoolNameId,InventoryTypeId =inventoryTypeId });
        return Ok(Inventorys);
    }

    

    [HttpGet]
    [Route("get-InventoryDetail/{id}")]
    public async Task<ActionResult<InventoryDto>> Get(int id)
    {
        var Inventory = await _mediator.Send(new GetInventoryDetailRequest { InventoryId = id });
        return Ok(Inventory);
    }
       
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Inventory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateInventoryDto Inventory)
    {
        var command = new CreateInventoryCommand { InventoryDto = Inventory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Inventory/{id}")]
    public async Task<ActionResult> Put([FromBody] InventoryDto Inventory)
    {
        var command = new UpdateInventoryCommand { InventoryDto = Inventory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Inventory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteInventoryCommand { InventoryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedInventorys")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedInventory()
    {
        var selectedInventory = await _mediator.Send(new GetSelectedInventoryRequest { });
        return Ok(selectedInventory);
    }


    [HttpGet]
    [Route("get-inventoryDetailListForDashboard")]
    public async Task<ActionResult<List<SelectedModel>>> getinventoryDetailListForDashboard(int baseSchoolNameId)
    {
        var InventoryDetailList = await _mediator.Send(new GetInventoryByTypeListBySpRequest { 
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(InventoryDetailList);
    }

    [HttpGet]
    [Route("get-inventoryDetailListByType")]
    public async Task<ActionResult<List<InventoryDto>>> getinventoryDetailListByType(int baseSchoolNameId)
    {
        var InventoryDetailList = await _mediator.Send(new GetInventoryByTypeListRequest { 
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(InventoryDetailList);
    }



    [HttpGet]
    [Route("get-inventoryListByType")]
    public async Task<ActionResult<List<InventoryDto>>> getinventoryListByType(int baseSchoolNameId, int inventoryTypeId)
    {
        var InventoryDetailList = await _mediator.Send(new GetInventoryListByTypeListBySpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            InventoryTypeId = inventoryTypeId
        });
        return Ok(InventoryDetailList);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-inventorystatus/{id}")]
    public async Task<ActionResult> UpdateInventory([FromBody] InventoryDto Inventory)
    {
        var command = new UpdateInventoryStatusCommand { InventoryDto = Inventory };
        await _mediator.Send(command);
        return NoContent();
    }
}

