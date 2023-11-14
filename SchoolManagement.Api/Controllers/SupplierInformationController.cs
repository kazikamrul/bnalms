using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SupplierInformation;
using SchoolManagement.Application.Features.SupplierInformations.Requests.Commands;
using SchoolManagement.Application.Features.SupplierInformations.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SupplierInformation)]
[ApiController]
[Authorize]
public class SupplierInformationController : ControllerBase
{
    private readonly IMediator _mediator;

    public SupplierInformationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-SupplierInformations")]
    public async Task<ActionResult<List<SupplierInformationDto>>> Get([FromQuery] QueryParams queryParams, int bookInformationId)
    {
        var SupplierInformations = await _mediator.Send(new GetSupplierInformationListRequest { QueryParams = queryParams, BookInformationId = bookInformationId });
        return Ok(SupplierInformations);
    }

    

    [HttpGet]
    [Route("get-SupplierInformationDetail/{id}")]
    public async Task<ActionResult<SupplierInformationDto>> Get(int id)
    {
        var SupplierInformation = await _mediator.Send(new GetSupplierInformationDetailRequest { SupplierInformationId = id });
        return Ok(SupplierInformation);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-SupplierInformation")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSupplierInformationDto SupplierInformation)
    {
        var command = new CreateSupplierInformationCommand { SupplierInformationDto = SupplierInformation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-SupplierInformation/{id}")]
    public async Task<ActionResult> Put([FromBody] SupplierInformationDto SupplierInformation)
    {
        var command = new UpdateSupplierInformationCommand { SupplierInformationDto = SupplierInformation };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-SupplierInformation/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSupplierInformationCommand { SupplierInformationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedSupplierInformations")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedSupplierInformation()
    {
        var selectedSupplierInformation = await _mediator.Send(new GetSelectedSupplierInformationRequest { });
        return Ok(selectedSupplierInformation);
    }
}

