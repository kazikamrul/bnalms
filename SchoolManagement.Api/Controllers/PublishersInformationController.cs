using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.PublishersInformation;
using SchoolManagement.Application.Features.PublishersInformations.Requests.Commands;
using SchoolManagement.Application.Features.PublishersInformations.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.PublishersInformation)]
[ApiController]
[Authorize]
public class PublishersInformationController : ControllerBase
{
    private readonly IMediator _mediator;

    public PublishersInformationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-PublishersInformations")]
    public async Task<ActionResult<List<PublishersInformationDto>>> Get([FromQuery] QueryParams queryParams, int bookInformationId)
    {
        var PublishersInformations = await _mediator.Send(new GetPublishersInformationListRequest { QueryParams = queryParams, BookInformationId = bookInformationId });
        return Ok(PublishersInformations);
    }

    

    [HttpGet]
    [Route("get-PublishersInformationDetail/{id}")]
    public async Task<ActionResult<PublishersInformationDto>> Get(int id)
    {
        var PublishersInformation = await _mediator.Send(new GetPublishersInformationDetailRequest { PublishersInformationId = id });
        return Ok(PublishersInformation);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-PublishersInformation")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreatePublishersInformationDto PublishersInformation)
    {
        var command = new CreatePublishersInformationCommand { PublishersInformationDto = PublishersInformation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-PublishersInformation/{id}")]
    public async Task<ActionResult> Put([FromBody] PublishersInformationDto PublishersInformation)
    {
        var command = new UpdatePublishersInformationCommand { PublishersInformationDto = PublishersInformation };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-PublishersInformation/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeletePublishersInformationCommand { PublishersInformationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedPublishersInformations")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedPublishersInformation()
    {
        var selectedPublishersInformation = await _mediator.Send(new GetSelectedPublishersInformationRequest { });
        return Ok(selectedPublishersInformation);
    }
}

