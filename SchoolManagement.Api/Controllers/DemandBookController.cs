using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DemandBook;
using SchoolManagement.Application.Features.DemandBooks.Requests.Commands;
using SchoolManagement.Application.Features.DemandBooks.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DemandBook)]
[ApiController]
[Authorize]
public class DemandBookController : ControllerBase
{
    private readonly IMediator _mediator;

    public DemandBookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-DemandBooks")]
    public async Task<ActionResult<List<DemandBookDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DemandBooks = await _mediator.Send(new GetDemandBookListRequest { QueryParams = queryParams });
        return Ok(DemandBooks);
    }

    

    [HttpGet]
    [Route("get-DemandBookDetail/{id}")]
    public async Task<ActionResult<DemandBookDto>> Get(int id)
    {
        var DemandBook = await _mediator.Send(new GetDemandBookDetailRequest { DemandBookId = id });
        return Ok(DemandBook);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-DemandBook")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDemandBookDto DemandBook)
    {
        var command = new CreateDemandBookCommand { DemandBookDto = DemandBook };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-DemandBook/{id}")]
    public async Task<ActionResult> Put([FromBody] DemandBookDto DemandBook)
    {
        var command = new UpdateDemandBookCommand { DemandBookDto = DemandBook };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-DemandBook/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDemandBookCommand { DemandBookId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedDemandBooks")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedDemandBook()
    {
        var selectedDemandBook = await _mediator.Send(new GetSelectedDemandBookRequest { });
        return Ok(selectedDemandBook);
    }
}

