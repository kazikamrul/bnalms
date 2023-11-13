using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BaseSchoolNames;
using SchoolManagement.Application.DTOs.BookIssueAndSubmission;
using SchoolManagement.Application.Features.BaseSchoolNames.Requests.Queries;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Commands;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BookIssueAndSubmission)]
[ApiController]
[Authorize]
public class BookIssueAndSubmissionController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookIssueAndSubmissionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bookIssueAndSubmissions")]
    public async Task<ActionResult<List<BookIssueAndSubmissionDto>>> Get([FromQuery] QueryParams queryParams, int baseSchoolNameId)
    {
        var BookIssueAndSubmissions = await _mediator.Send(new GetBookIssueAndSubmissionListRequest
        {
            QueryParams = queryParams,
            BaseSchoolNameId =baseSchoolNameId
        });
        return Ok(BookIssueAndSubmissions);
    }

    

    [HttpGet]
    [Route("get-bookIssueAndSubmissionDetail/{id}")]
    public async Task<ActionResult<BookIssueAndSubmissionDto>> Get(int id)
    {
        var BookIssueAndSubmission = await _mediator.Send(new GetBookIssueAndSubmissionDetailRequest { BookIssueAndSubmissionId = id });
        return Ok(BookIssueAndSubmission);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bookIssueAndSubmission")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBookIssueAndSubmissionDto BookIssueAndSubmission)
    {
        var command = new CreateBookIssueAndSubmissionCommand { BookIssueAndSubmissionDto = BookIssueAndSubmission };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bookIssueAndSubmissionList")]

    public async Task<ActionResult<BaseCommandResponse>> SaveBookIssueAndSubmissionList([FromBody] CreateBookIssueAndSubmissionListDto BookIssueAndSubmissionList)
    {
        var command = new CreateBookIssueAndSubmissionListCommand { BookIssueAndSubmissionDto = BookIssueAndSubmissionList };
        var response = await _mediator.Send(command);
        return Ok(response);
        //return Ok();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bookIssueAndSubmission/{id}")]
    public async Task<ActionResult> Put([FromBody] BookIssueAndSubmissionDto BookIssueAndSubmission)
    {
        var command = new UpdateBookIssueAndSubmissionCommand { BookIssueAndSubmissionDto = BookIssueAndSubmission };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bookIssueAndSubmission/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBookIssueAndSubmissionCommand { BookIssueAndSubmissionId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBookIssueAndSubmissions")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedBookIssueAndSubmission()
    {
        var selectedBookIssueAndSubmission = await _mediator.Send(new GetSelectedBookIssueAndSubmissionRequest { });
        return Ok(selectedBookIssueAndSubmission);
    }

    [HttpGet]

    [Route("get-bookIssueListByMemberInfoId")]
    public async Task<ActionResult> GetBookIssueListByMemberInfoId(int memberInfoId)
    {
        var equipmentName = await _mediator.Send(new GetBookIssueListByMemberInfoIdRequest
        {
            MemberInfoId = memberInfoId
        });
        return Ok(equipmentName);
    }

    [HttpGet]
    [Route("return-bookIssueAndSubmissions")]
    public async Task<ActionResult> returnBookIssueAndSubmission(int bookIssueAndSubmissionId, int returnStatus)
    {
        var returnBookIssueAndSubmission = await _mediator.Send(new ReturnBookIssueAndSubmissionCommand {
            BookIssueAndSubmissionId=bookIssueAndSubmissionId,
            ReturnStatus=returnStatus
        });
        return Ok(returnBookIssueAndSubmission);
    }


    [HttpGet]
    [Route("get-bookIssueAndSubmissionsListByUser")]
    public async Task<ActionResult<List<BookIssueAndSubmissionDto>>> GetBookIssueAndSubmissionsListByUser(int userId)
    {
        var bookIssueAndSubmissionsListByUser = await _mediator.Send(new GetBookIssueAndSubmissionListByUserRequest { 
            MemberInfoId = userId
        });
        return Ok(bookIssueAndSubmissionsListByUser);

    }
    [HttpGet]
    [Route("get-bookIssueAndSubmissionsListByIsDamaged")]
    public async Task<ActionResult<List<BookIssueAndSubmissionDto>>> GetBookIssueAndSubmissionListByIsDamaged([FromQuery] QueryParams queryParams)
    {
        var BookIssueAndSubmissions = await _mediator.Send(new GetBookIssueAndSubmissionListByIsDamagedRequest
        {
            QueryParams = queryParams,
            //BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(BookIssueAndSubmissions);
    }

    [HttpGet]
    [Route("get-bookissueandsubmissionforfine")]
    public async Task<ActionResult> GetOnlineBookRequestList(int memberInfoId,int baseSchoolNameId,string searchText)
     {
        var bookIssueAndSubmission = await _mediator.Send(new GetBookIssuedListForFineBySpRequest
        {
            MemberInfoId = memberInfoId,
            BaseSchoolNameId =baseSchoolNameId,
            SearchText =searchText
        });
        return Ok(bookIssueAndSubmission);
    }

    [HttpGet]
    [Route("get-bookissueandsubmissionforfinebybaseschoolnameid")]
    public async Task<ActionResult> GetBookIssueAndSubmissionListByBaseSchoolName(int baseSchoolNameId,string searchText)
    {
        var bookIssueAndSubmission = await _mediator.Send(new GetBookIssueAndSubmissionListByBaseSchoolNameIdSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            SearchText = searchText
        });
        return Ok(bookIssueAndSubmission);
    }
}

