using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.OnlineBookRequest;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
using SchoolManagement.Application.Features.Demands.Requests.Queries;
using SchoolManagement.Application.Features.OnlineBookRequests.Requests.Commands;
using SchoolManagement.Application.Features.OnlineBookRequests.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.OnlineBookRequest)]
[ApiController]
[Authorize]
public class OnlineBookRequestController : ControllerBase
{
    private readonly IMediator _mediator;

    public OnlineBookRequestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-OnlineBookRequests")]
    public async Task<ActionResult<List<OnlineBookRequestDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var OnlineBookRequests = await _mediator.Send(new GetOnlineBookRequestListRequest { QueryParams = queryParams });
        return Ok(OnlineBookRequests);
    }

    [HttpGet]
    [Route("get-onlineBookRequestsByMemberId")]
    public async Task<ActionResult<List<OnlineBookRequestDto>>> GetOnlineBookRequestByMemberId([FromQuery] QueryParams queryParams,int memberId)
    {
        var OnlineBookRequests = await _mediator.Send(new GetOnlineBookRequestListByMemberInfoIdRequest
        {
            QueryParams = queryParams,
            MemberInfoId =memberId
        });
        return Ok(OnlineBookRequests);
    }


    [HttpGet]
    [Route("get-OnlineBookRequestDetail/{id}")]
    public async Task<ActionResult<OnlineBookRequestDto>> Get(int id)
    {
        var OnlineBookRequest = await _mediator.Send(new GetOnlineBookRequestDetailRequest { OnlineBookRequestId = id });
        return Ok(OnlineBookRequest);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-OnlineBookRequest")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateOnlineBookRequestDto OnlineBookRequest)
    {
        var command = new CreateOnlineBookRequestCommand { OnlineBookRequestDto = OnlineBookRequest };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-OnlineBookRequest/{id}")]
    public async Task<ActionResult> Put([FromBody] OnlineBookRequestDto OnlineBookRequest)
    {
        var command = new UpdateOnlineBookRequestCommand { OnlineBookRequestDto = OnlineBookRequest };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-requestandcancelstatus/{id}")]
    public async Task<ActionResult> UpdateRequestAndCancelStatus([FromBody] int onlineBookRequsetId)
    {
        var command = new UpdateRequestAndCancelStatusCommand { OnlineBookRequestId = onlineBookRequsetId };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType] 
    [Route("update-issueonlinerequestcountandcancelstatus")]
    public async Task<ActionResult> UpdateIssueOnlineCountAndCancelStatus(int onlineBookRequsetId,int bookInformationId)
    {
        var command = new UpdateIssueAndCancelStatusCommand
        { 
            OnlineBookRequestId = onlineBookRequsetId,
            BookInformationId =bookInformationId
        };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-OnlineBookRequest/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteOnlineBookRequestCommand { OnlineBookRequestId = id };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("user-onlineBookRequest")]
    public async Task<ActionResult> OnlineBookRequest(int bookInformationId, int memberInfoId)
    {
        var OnlineBookRequest = await _mediator.Send(new UserOnlineBookRequest { 
            BookInformationId = bookInformationId,
            MemberInfoId = memberInfoId
        });
        return Ok(OnlineBookRequest);
    }

    [HttpGet]
    [Route("get-onlineBookRequestListByBookInfo")]
    public async Task<ActionResult> GetOnlineBookRequestByBookInfo(int bookInformationId)
    {
        var OnlineBookRequest = await _mediator.Send(new GetOnlineBookRequestListByBookInformationRequest { BookInformationId = bookInformationId });
        return Ok(OnlineBookRequest);
    }


    [HttpGet]
    [Route("get-onlineBookRequestListByMemberInfoId")]
    public async Task<ActionResult> GetOnlineBookInfoListByMemberInfoId(int memberid)
    {
        var OnlineBookRequest = await _mediator.Send(new GetOnlineBookRequestListByParameterRequest
        {
            MemberInfoId = memberid
        });
        return Ok(OnlineBookRequest);
    }


    [HttpGet]
    [Route("get-onlineRequestIsExistCheck")]
    public async Task<ActionResult<bool>> GetOnlineRequestIsExistCheck(int bookInformationId, int MemberInfoId)
    {
        var isExist = await _mediator.Send(new GetOnlineRequestIsExistCheckRequest
        {
            BookInformationId=bookInformationId,
            MemberInfoId = MemberInfoId
        });
        return Ok(isExist);
    }

    [HttpGet]
    [Route("get-onlineBookRequestCountByMemberAndLibrary")]
    public async Task<ActionResult> GetOnlineBookRequestCountByMemberAndLibrary(int baseSchoolNameId, int memberInfoId)
    {
        var OnlineBookRequest = await _mediator.Send(new GetOnlineBookRequestCountByMemberAndLibraryBySpRequest
        {
            BaseSchoolNameId =baseSchoolNameId,
            MemberInfoId = memberInfoId
        });
        return Ok(OnlineBookRequest);
    }
}

