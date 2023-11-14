using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.FineForIssueReturns;
using SchoolManagement.Application.Features.FineForIssueReturns.Requests.Commands;
using SchoolManagement.Application.Features.FineForIssueReturns.Requests.Queries;
using SchoolManagement.Application.Features.MemberInfos.Requests.Commands;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.FineForIssueReturns)]
[ApiController]
[Authorize]
public class FineForIssueReturnController : ControllerBase
{
    private readonly IMediator _mediator;

    public FineForIssueReturnController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-FineForIssueReturns")]
    public async Task<ActionResult<List<FineForIssueReturnDto>>> Get([FromQuery] QueryParams queryParams, int baseSchoolNameId)
    {
        var FineForIssueReturns = await _mediator.Send(new GetFineForIssueReturnListRequest { QueryParams = queryParams, BaseSchoolNameId = baseSchoolNameId });
        return Ok(FineForIssueReturns);
    }

    [HttpGet]
    [Route("get-FineForIssueReturnDetail/{id}")]
    public async Task<ActionResult<FineForIssueReturnDto>> Get(int id)
    {
        var FineForIssueReturn = await _mediator.Send(new GetFineForIssueReturnDetailRequest { FineForIssueReturnId = id });
        return Ok(FineForIssueReturn);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-FineForIssueReturn")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateFineForIssueReturnDto FineForIssueReturn)
    {
        var command = new CreateFineForIssueReturnCommand { FineForIssueReturnDto = FineForIssueReturn };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-FineForIssueReturn/{id}")]
    public async Task<ActionResult> Put([FromBody] FineForIssueReturnDto FineForIssueReturn)
    {
        var command = new UpdateFineForIssueReturnCommand { FineForIssueReturnDto = FineForIssueReturn };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-FineForIssueReturn/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteFineForIssueReturnCommand { FineForIssueReturnId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedFineForIssueReturns")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedFineForIssueReturn()
    {
        var selectedFineForIssueReturn = await _mediator.Send(new GetSelectedFineForIssueReturnRequest { });
        return Ok(selectedFineForIssueReturn);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("active-fineForIssueReturn/{id}")]
    public async Task<ActionResult> AcceptMeaSquadronState(int id)
    {
        var command = new ActiveFineForIssueReturnCommand { FineForIssueReturnId = id };
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("inActive-fineForIssueReturn/{id}")]
    public async Task<ActionResult> CalcelMeaSquadronState(int id)
    {
        var command = new InActiveFineForIssueReturnCommand { FineForIssueReturnId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

