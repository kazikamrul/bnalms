using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.LibraryAuthority;
using SchoolManagement.Application.Features.LibraryAuthoritys.Requests.Commands;
using SchoolManagement.Application.Features.LibraryAuthoritys.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.LibraryAuthority)]
[ApiController]
[Authorize]
public class LibraryAuthorityController : ControllerBase
{
    private readonly IMediator _mediator;

    public LibraryAuthorityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-LibraryAuthorities")]
    public async Task<ActionResult<List<LibraryAuthorityDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var LibraryAuthoritys = await _mediator.Send(new GetLibraryAuthorityListRequest { QueryParams = queryParams });
        return Ok(LibraryAuthoritys);
    }

    

    [HttpGet]
    [Route("get-LibraryAuthorityDetail/{id}")]
    public async Task<ActionResult<LibraryAuthorityDto>> Get(int id)
    {
        var LibraryAuthority = await _mediator.Send(new GetLibraryAuthorityDetailRequest { LibraryAuthorityId = id });
        return Ok(LibraryAuthority);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-LibraryAuthority")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLibraryAuthorityDto LibraryAuthority)
    {
        var command = new CreateLibraryAuthorityCommand { LibraryAuthorityDto = LibraryAuthority };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-LibraryAuthority/{id}")]
    public async Task<ActionResult> Put([FromBody] LibraryAuthorityDto LibraryAuthority)
    {
        var command = new UpdateLibraryAuthorityCommand { LibraryAuthorityDto = LibraryAuthority };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-LibraryAuthority/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLibraryAuthorityCommand { LibraryAuthorityId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedLibraryAuthorities")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedLibraryAuthority()
    {
        var selectedLibraryAuthority = await _mediator.Send(new GetSelectedLibraryAuthorityRequest { });
        return Ok(selectedLibraryAuthority);
    }
}

