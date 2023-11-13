using SchoolManagement.Application;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries;
using SchoolManagement.Application.Features.Demands.Requests.Queries;
using SchoolManagement.Application.Features.MemberInfos.Requests.Queries;
using SchoolManagement.Application.Features.NoticeInfos.Requests.Queries;
using SchoolManagement.Application.Features.SoftCopyUploads.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Dashboard)]
[ApiController]
[Authorize]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    } 

    [HttpGet]
    [Route("get-bookInfoListByBaseSchoolNameIdSpRequest")]
    public async Task<ActionResult> GetBookInfoListByBaseSchoolNameIdSpRequest(int baseSchoolNameId)
    {
        var bookList = await _mediator.Send(new GetBookInfoListSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(bookList);
    }

    [HttpGet]
    [Route("get-softCopyUploadByType")] 
    public async Task<ActionResult> GetSoftCopyUploadByType(int documentTypeId)
    {
        var softCopies = await _mediator.Send(new GetSoftCopyUploadsByTypeListSpRequest
        {
            DocumentTypeId = documentTypeId
        });
        return Ok(softCopies); 
    }

    [HttpGet]
    [Route("get-noticeInfoCountByMember")] 
    public async Task<ActionResult> GetNoticeInfoCountByMemberRequest(int memberInfoId)
    {
        var noticeCount = await _mediator.Send(new GetNoticeInfoCountByMemberRequest
        {
            MemberInfoId = memberInfoId
        });
        return Ok(noticeCount); 
    }

    [HttpGet]
    [Route("get-bookIssueListBySpRequest")]
    public async Task<ActionResult> GetBookIssueListBySpRequest(int baseSchoolNameId,string searchText)
    {
        var presentStocks = await _mediator.Send(new GetBookIssueListBySpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            SearchText = searchText
        });
        return Ok(presentStocks);
    }

    [HttpGet]
    [Route("get-allMemberInfoListBySpRequest")]
    public async Task<ActionResult> GetAllMemberInfoListBySpRequest(string searchText)
    {
        var presentStocks = await _mediator.Send(new GetAllMemberInfoListBySpRequest
        {
            // BaseSchoolNameId = baseSchoolNameId,
            SearchText = searchText
        });
        return Ok(presentStocks);
    }

    [HttpGet]
    [Route("get-memberInfoListByLibrarySpRequest")]
    public async Task<ActionResult> GetMemberInfoListByLibrarySpRequest(int baseSchoolNameId, string searchText)
    {
        var presentStocks = await _mediator.Send(new GetMemberInfoListByLibrarySpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            SearchText = searchText
        });
        return Ok(presentStocks);
    }

    [HttpGet]
    [Route("get-bookIssuedListForMemberInfoBySpRequest")]
    public async Task<ActionResult> GetBookIssuedListForMemberInfoBySpRequest(int memberInfoId, string searchText)
    {
        var presentStocks = await _mediator.Send(new GetBookIssuedListForMemberInfoBySpRequest
        {
            MemberInfoId = memberInfoId,
            SearchText = searchText
        });
        return Ok(presentStocks);
    }
}

