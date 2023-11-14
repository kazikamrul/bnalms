using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DamageInformationByLibrary;
using SchoolManagement.Application.Features.DamageInformationByLibrarys.Requests.Commands;
using SchoolManagement.Application.Features.DamageInformationByLibrarys.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DamageInformationByLibrary)]
[ApiController]
[Authorize]
public class DamageInformationByLibraryController : ControllerBase
{
    private readonly IMediator _mediator;

    public DamageInformationByLibraryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-DamageInformationByLibraryies")]
    public async Task<ActionResult<List<DamageInformationByLibraryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DamageInformationByLibrarys = await _mediator.Send(new GetDamageInformationByLibraryListRequest { QueryParams = queryParams });
        return Ok(DamageInformationByLibrarys);
    }

    

    [HttpGet]
    [Route("get-DamageInformationByLibraryDetail/{id}")]
    public async Task<ActionResult<DamageInformationByLibraryDto>> Get(int id)
    {
        var DamageInformationByLibrary = await _mediator.Send(new GetDamageInformationByLibraryDetailRequest { DamageInformationByLibraryId = id });
        return Ok(DamageInformationByLibrary);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-DamageInformationByLibrary")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDamageInformationByLibraryDto DamageInformationByLibrary)
    {
        var command = new CreateDamageInformationByLibraryCommand { DamageInformationByLibraryDto = DamageInformationByLibrary };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-DamageInformationByLibrary/{id}")]
    public async Task<ActionResult> Put([FromBody] DamageInformationByLibraryDto DamageInformationByLibrary)
    {
        var command = new UpdateDamageInformationByLibraryCommand { DamageInformationByLibraryDto = DamageInformationByLibrary };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-DamageInformationByLibrary/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDamageInformationByLibraryCommand { DamageInformationByLibraryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedDamageInformationByLibraries")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedDamageInformationByLibrary()
    {
        var selectedDamageInformationByLibrary = await _mediator.Send(new GetSelectedDamageInformationByLibraryRequest { });
        return Ok(selectedDamageInformationByLibrary);
    }
}

