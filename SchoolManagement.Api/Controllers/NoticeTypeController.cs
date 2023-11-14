using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.NoticeType;
using SchoolManagement.Application.Features.NoticeTypes.Requests.Commands;
using SchoolManagement.Application.Features.NoticeTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.NoticeType)]
[ApiController]
[Authorize]
public class NoticeTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public NoticeTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-NoticeTypes")]
    public async Task<ActionResult<List<NoticeTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var NoticeTypes = await _mediator.Send(new GetNoticeTypeListRequest { QueryParams = queryParams });
        return Ok(NoticeTypes);
    }

    

    [HttpGet]
    [Route("get-NoticeTypeDetail/{id}")]
    public async Task<ActionResult<NoticeTypeDto>> Get(int id)
    {
        var NoticeType = await _mediator.Send(new GetNoticeTypeDetailRequest { NoticeTypeId = id });
        return Ok(NoticeType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-NoticeType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateNoticeTypeDto NoticeType)
    {
        var command = new CreateNoticeTypeCommand { NoticeTypeDto = NoticeType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-NoticeType/{id}")]
    public async Task<ActionResult> Put([FromBody] NoticeTypeDto NoticeType)
    {
        var command = new UpdateNoticeTypeCommand { NoticeTypeDto = NoticeType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-NoticeType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteNoticeTypeCommand { NoticeTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedNoticeTypes")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedNoticeType()
    {
        var selectedNoticeType = await _mediator.Send(new GetSelectedNoticeTypeRequest { });
        return Ok(selectedNoticeType);
    }
}

