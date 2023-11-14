using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MainClass;
using SchoolManagement.Application.Features.MainClasses.Requests.Commands;
using SchoolManagement.Application.Features.MainClasses.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MainClass)]
[ApiController]
[Authorize]
public class MainClassController : ControllerBase
{
    private readonly IMediator _mediator;

    public MainClassController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-MainClasses")]
    public async Task<ActionResult<List<MainClassDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MainClasss = await _mediator.Send(new GetMainClassListRequest { QueryParams = queryParams });
        return Ok(MainClasss);
    }

    

    [HttpGet]
    [Route("get-MainClassDetail/{id}")]
    public async Task<ActionResult<MainClassDto>> Get(int id)
    {
        var MainClass = await _mediator.Send(new GetMainClassDetailRequest { MainClassId = id });
        return Ok(MainClass);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-MainClass")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMainClassDto MainClass)
    {
        var command = new CreateMainClassCommand { MainClassDto = MainClass };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-MainClass/{id}")]
    public async Task<ActionResult> Put([FromBody] MainClassDto MainClass)
    {
        var command = new UpdateMainClassCommand { MainClassDto = MainClass };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-MainClass/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMainClassCommand { MainClassId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedMainClasses")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedMainClass()
    {
        var selectedMainClass = await _mediator.Send(new GetSelectedMainClassRequest { });
        return Ok(selectedMainClass);
    }
}

