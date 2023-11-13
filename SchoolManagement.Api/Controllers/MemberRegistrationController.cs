using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MemberRegistration;
using SchoolManagement.Application.Features.MemberRegistrations.Requests.Commands;
using SchoolManagement.Application.Features.MemberRegistrations.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MemberRegistration)]
[ApiController]
[Authorize]
public class MemberRegistrationController : ControllerBase
{
    private readonly IMediator _mediator;

    public MemberRegistrationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-MemberRegistrations")]
    public async Task<ActionResult<List<MemberRegistrationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MemberRegistrations = await _mediator.Send(new GetMemberRegistrationListRequest { QueryParams = queryParams });
        return Ok(MemberRegistrations);
    }

    

    [HttpGet]
    [Route("get-MemberRegistrationDetail/{id}")]
    public async Task<ActionResult<MemberRegistrationDto>> Get(int id)
    {
        var MemberRegistration = await _mediator.Send(new GetMemberRegistrationDetailRequest { MemberRegistrationId = id });
        return Ok(MemberRegistration);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-MemberRegistration")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMemberRegistrationDto MemberRegistration)
    {
        var command = new CreateMemberRegistrationCommand { MemberRegistrationDto = MemberRegistration };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-MemberRegistration/{id}")]
    public async Task<ActionResult> Put([FromBody] MemberRegistrationDto MemberRegistration)
    {
        var command = new UpdateMemberRegistrationCommand { MemberRegistrationDto = MemberRegistration };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-MemberRegistration/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMemberRegistrationCommand { MemberRegistrationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedMemberRegistrations")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedMemberRegistration()
    {
        var selectedMemberRegistration = await _mediator.Send(new GetSelectedMemberRegistrationRequest { });
        return Ok(selectedMemberRegistration);
    }
}

