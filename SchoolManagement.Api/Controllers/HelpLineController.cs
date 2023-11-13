using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.HelpLine;
using SchoolManagement.Application.Features.HelpLines.Requests.Commands;
using SchoolManagement.Application.Features.HelpLines.Requests.Queries;
using SchoolManagement.Application.Features.MemberInfos.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.HelpLine)]
[ApiController]
[Authorize]
public class HelpLineController : ControllerBase
{
    private readonly IMediator _mediator;

    public HelpLineController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-HelpLines")]
    public async Task<ActionResult<List<HelpLineDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var HelpLines = await _mediator.Send(new GetHelpLineListRequest { QueryParams = queryParams });
        return Ok(HelpLines);
    }

    

    [HttpGet]
    [Route("get-HelpLineDetail/{id}")]
    public async Task<ActionResult<HelpLineDto>> Get(int id)
    {
        var HelpLine = await _mediator.Send(new GetHelpLineDetailRequest { HelpLineId = id });
        return Ok(HelpLine);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-HelpLine")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateHelpLineDto HelpLine)
    {
        var command = new CreateHelpLineCommand { HelpLineDto = HelpLine };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-HelpLine/{id}")]
    public async Task<ActionResult> Put([FromBody] HelpLineDto HelpLine)
    {
        var command = new UpdateHelpLineCommand { HelpLineDto = HelpLine };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-HelpLine/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteHelpLineCommand { HelpLineId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedHelpLines")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedHelpLine()
    {
        var selectedHelpLine = await _mediator.Send(new GetSelectedHelpLineRequest { });
        return Ok(selectedHelpLine);
    }
    [HttpGet]
    [Route("get-helpLineListByDepartmentId")]
    public async Task<ActionResult> GetHelpLineListByDepartmentId(int baseSchoolNameId)
    {
        var equipmentName = await _mediator.Send(new GetHelpLineListByDepartmentIdRequest
        {
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(equipmentName);
    }
}

