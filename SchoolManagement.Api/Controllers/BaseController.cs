using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Base;
using SchoolManagement.Application.Features.Bases.Requests.Commands;
using SchoolManagement.Application.Features.Bases.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Base)]
[ApiController]
[Authorize]
public class BaseController : ControllerBase
{
    private readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Bases")]
    public async Task<ActionResult<List<BaseDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Bases = await _mediator.Send(new GetBaseListRequest { QueryParams = queryParams });
        return Ok(Bases);
    }

    

    [HttpGet]
    [Route("get-BaseDetail/{id}")]
    public async Task<ActionResult<BaseDto>> Get(int id)
    {
        var Base = await _mediator.Send(new GetBaseDetailRequest { BaseId = id });
        return Ok(Base);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Base")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBasemDto Base)
    {
        var command = new CreateBaseCommand { BasemDto = Base };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Base/{id}")]
    public async Task<ActionResult> Put([FromBody] BasemDto Base)
    {
        var command = new UpdateBaseCommand { BasemDto = Base };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Base/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBaseCommand { BaseId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBases")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedBase()
    {
        var selectedBase = await _mediator.Send(new GetSelectedBaseRequest { });
        return Ok(selectedBase);
    }
}

