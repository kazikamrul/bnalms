using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.NoticeInfo;
using SchoolManagement.Application.Features.NoticeInfos.Requests.Commands;
using SchoolManagement.Application.Features.NoticeInfos.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.NoticeInfo)]
[ApiController]
[Authorize]
public class NoticeInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public NoticeInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-NoticeInfos")]
    public async Task<ActionResult<List<NoticeInfoDto>>> Get([FromQuery] QueryParams queryParams,int noticeTypeId)
    {
        var NoticeInfos = await _mediator.Send(new GetNoticeInfoListRequest
        { 
            QueryParams = queryParams,
            NoticeTypeId =noticeTypeId
            
        });
        return Ok(NoticeInfos);
    }

    [HttpGet]
    [Route("get-NoticeInfoByMember")]
    public async Task<ActionResult<List<NoticeInfoDto>>> GetNoticeInfoByMember([FromQuery] QueryParams queryParams, int memberInfoId)
    {
        var NoticeInfos = await _mediator.Send(new GetNoticeInfoListByMemberRequest
        { 
            MemberInfoId = memberInfoId,
            QueryParams = queryParams 
        });
        return Ok(NoticeInfos);
    }

    

    [HttpGet]
    [Route("get-NoticeInfoDetail/{id}")]
    public async Task<ActionResult<NoticeInfoDto>> Get(int id)
    {
        var NoticeInfo = await _mediator.Send(new GetNoticeInfoDetailRequest { NoticeInfoId = id });
        return Ok(NoticeInfo);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-NoticeInfo")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateNoticeInfoDto NoticeInfo)
    {
        var command = new CreateNoticeInfoCommand { NoticeInfoDto = NoticeInfo };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpGet]
    [Route("update-noticeInfoListByMember")]
    public async Task<ActionResult<NoticeInfoDto>> UpdateNoticeInfoListByMember(int memberInfoId)
    {
        var NoticeInfoByMember = await _mediator.Send(new UpdateNoticeInfoListByMemberCommand
        { 
            MemberInfoId = memberInfoId
        });
        return Ok(NoticeInfoByMember);
    }

    [HttpGet]
    [Route("update-noticeInfoDetailByMember")]
    public async Task<ActionResult<NoticeInfoDto>> UpdateNoticeInfoDetailByMember(int noticeInfoId)
    {
        var NoticeInfoDetailByMember = await _mediator.Send(new UpdateNoticeInfoDetailByMemberCommand
        { 
            NoticeInfoId = noticeInfoId
        });
        return Ok(NoticeInfoDetailByMember);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-NoticeInfo/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateNoticeInfoDto NoticeInfo)
    {
        var command = new UpdateNoticeInfoCommand { CreateNoticeInfoDto = NoticeInfo };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-NoticeInfo/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteNoticeInfoCommand { NoticeInfoId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedNoticeInfos")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedNoticeInfo()
    {
        var selectedNoticeInfo = await _mediator.Send(new GetSelectedNoticeInfoRequest { });
        return Ok(selectedNoticeInfo);
    }
}

