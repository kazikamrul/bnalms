using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.InformationFezup;
using SchoolManagement.Application.Features.InformationFezups.Requests.Commands;
using SchoolManagement.Application.Features.InformationFezups.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.InformationFezup)]
[ApiController]
[Authorize]
public class InformationFezupController : ControllerBase
{
    private readonly IMediator _mediator;

    public InformationFezupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-InformationFezups")]
    public async Task<ActionResult<List<InformationFezupDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var InformationFezups = await _mediator.Send(new GetInformationFezupListRequest { QueryParams = queryParams });
        return Ok(InformationFezups);
    }

    

    [HttpGet]
    [Route("get-InformationFezupDetail/{id}")]
    public async Task<ActionResult<InformationFezupDto>> Get(int id)
    {
        var InformationFezup = await _mediator.Send(new GetInformationFezupDetailRequest { InformationFezupId = id });
        return Ok(InformationFezup);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-InformationFezup")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateInformationFezupDto InformationFezup)
    {
        var command = new CreateInformationFezupCommand { InformationFezupDto = InformationFezup };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-InformationFezup/{id}")]
    public async Task<ActionResult> Put([FromBody] InformationFezupDto InformationFezup)
    {
        var command = new UpdateInformationFezupCommand { InformationFezupDto = InformationFezup };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-InformationFezup/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteInformationFezupCommand { InformationFezupId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedInformationFezups")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedInformationFezup()
    {
        var selectedInformationFezup = await _mediator.Send(new GetSelectedInformationFezupRequest { });
        return Ok(selectedInformationFezup);
    }
}

