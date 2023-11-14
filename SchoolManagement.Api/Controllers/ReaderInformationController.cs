using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ReaderInformation;
using SchoolManagement.Application.Features.ReaderInformations.Requests.Commands;
using SchoolManagement.Application.Features.ReaderInformations.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ReaderInformation)]
[ApiController]
[Authorize]
public class ReaderInformationController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReaderInformationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ReaderInformations")]
    public async Task<ActionResult<List<ReaderInformationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ReaderInformations = await _mediator.Send(new GetReaderInformationListRequest { QueryParams = queryParams });
        return Ok(ReaderInformations);
    }

    

    [HttpGet]
    [Route("get-ReaderInformationDetail/{id}")]
    public async Task<ActionResult<ReaderInformationDto>> Get(int id)
    {
        var ReaderInformation = await _mediator.Send(new GetReaderInformationDetailRequest { ReaderInformationId = id });
        return Ok(ReaderInformation);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ReaderInformation")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateReaderInformationDto ReaderInformation)
    {
        var command = new CreateReaderInformationCommand { ReaderInformationDto = ReaderInformation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-ReaderInformation/{id}")]
    public async Task<ActionResult> Put([FromBody] ReaderInformationDto ReaderInformation)
    {
        var command = new UpdateReaderInformationCommand { ReaderInformationDto = ReaderInformation };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ReaderInformation/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteReaderInformationCommand { ReaderInformationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedReaderInformations")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedReaderInformation()
    {
        var selectedReaderInformation = await _mediator.Send(new GetSelectedReaderInformationRequest { });
        return Ok(selectedReaderInformation);
    }
}

