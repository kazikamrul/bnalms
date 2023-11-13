using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BookInformation;
using SchoolManagement.Application.Features.BookInformations.Requests.Commands;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
using SchoolManagement.Application.Features.Demands.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BookInformation)]
[ApiController]
[Authorize]
public class BookInformationController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookInformationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-BookInformations")]
    public async Task<ActionResult<List<BookInformationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BookInformations = await _mediator.Send(new GetBookInformationListRequest { QueryParams = queryParams });
        return Ok(BookInformations);
    }

    

    [HttpGet]
    [Route("get-BookInformationDetail/{id}")]
    public async Task<ActionResult<BookInformationDto>> Get(int id)
    {
        var BookInformation = await _mediator.Send(new GetBookInformationDetailRequest { BookInformationId = id });
        return Ok(BookInformation);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-BookInformation")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateBookInformationDto BookInformation)
    {
        var command = new CreateBookInformationCommand { BookInformationDto = BookInformation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-BookInformation/{id}")]
    public async Task<ActionResult> Put([FromForm] BookInformationDto BookInformation)
    {
        var command = new UpdateBookInformationCommand { BookInformationDto = BookInformation };
        var info_id = command.BookInformationDto;
        var response = await _mediator.Send(command);
        //await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-BookInformation/{id}")]
    public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
    {
        var command = new DeleteBookInformationCommand { BookInformationId = id };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    // relational data get 

    [HttpGet]
    [Route("get-selectedBookInformations")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedBookInformation()
    {
        var selectedBookInformation = await _mediator.Send(new GetSelectedBookInformationRequest { });
        return Ok(selectedBookInformation);
    }
    [HttpGet]
    [Route("get-autocompleteAccessionNo")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompleteAccessionNo(string accessionNo)
    {
        var course = await _mediator.Send(new GetAutoCompleteAccessionNoRequest
        {
            accessionNo = accessionNo,
        });
        return Ok(course);
    } 
    [HttpGet]
    [Route("get-autocompleteAccessionNoByDept")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompleteAccessionNo(string accessionNo, int departmentId)
    {
        var course = await _mediator.Send(new GetAutoCompleteAccessionNoByDeptRequest
        {
            accessionNo = accessionNo,
            DepartmentId = departmentId
        });
        return Ok(course);
    } 

    [HttpGet]
    [Route("get-bookInformationListBySp")]
    public async Task<ActionResult> GetBookInformationListBySp(int baseSchoolNameId,string searchText,int bookCategoryId,int pageSize, int pageNumber)
    {
        var presentStocks = await _mediator.Send(new GetBookInformationListBySpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            SearchText = searchText,
            BookCategoryId = bookCategoryId,
            PageSize =pageSize,
            PageNumber =pageNumber
        });
        return Ok(presentStocks);
    }

    [HttpGet]
    [Route("get-bookInformationListForMemberBySp")]
    public async Task<ActionResult> GetBookInformationListForMemberBySp(int memberInfoId, int baseSchoolNameId, string searchText, int bookCategoryId, int bookTitleInfoId)
    {
        var presentStocks = await _mediator.Send(new GetBookInformationListForMemberBySpRequest
        {
            MemberInfoId = memberInfoId,
            BaseSchoolNameId = baseSchoolNameId,
            SearchText = searchText,
            BookCategoryId = bookCategoryId,
            BookTitleInfoId = bookTitleInfoId
        });
        return Ok(presentStocks);
    }

    [HttpGet]
    [Route("get-accessionNoIsExistCheck")]
    public async Task<ActionResult<bool>> GetAccessionNoIsEXistCheck(string accessionNo)
    {
        var isExist = await _mediator.Send(new GetAccessionNoIsExistCheckRequest
        {
            AccessionNo = accessionNo,
        });
        return Ok(isExist);
    }

    [HttpGet]
    [Route("get-onlineBookRequestIsExistCheck")]
    public async Task<ActionResult<bool>> GetOnlineBookRequestIsExistCheck(int pno,int bookInformationId)
    {
        var isExist = await _mediator.Send(new GetOnlineBookRequestIsExistCheckRequest
        {
           BookInformationId=bookInformationId,
           Pno =pno
        });
        return Ok(isExist);
    }

    [HttpGet]
    [Route("get-bookIssueInfoByUserSp")]
    public async Task<ActionResult> GetBookIssueInfoByUser(int bookInformationId)
    {
        var presentStocks = await _mediator.Send(new GetBookIssueInfoByUserSpRequest
        {
            BookInformationId = bookInformationId
        });
        return Ok(presentStocks);
    }

    [HttpGet] 
    [Route("get-onlinebookrequestlistsp")]
    public async Task<ActionResult> GetOnlineBookRequestList(int baseSchoolNameId, string searchText)
    {
        var onlineBookRequests = await _mediator.Send(new GetOnlineBookRequestListBySpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            SearchText = searchText
        });
        return Ok(onlineBookRequests);
    }

    [HttpGet] 
    [Route("get-bookListByTitle")]
    public async Task<ActionResult> GetBookListByTitleSpRequest(int baseSchoolNameId, int bookCategoryId)
    {
        var BookListByTitle = await _mediator.Send(new GetBookListByTitleSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            BookCategoryId = bookCategoryId
        });
        return Ok(BookListByTitle);
    }

    [HttpGet] 
    [Route("get-bookDetailByTitle")]
    public async Task<ActionResult> GetBookDetailByTitleSpRequest(int baseSchoolNameId,int bookTitleInfoId)
    {
        var BookDetailByTitle = await _mediator.Send(new GetBookDetailByTitleSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            BookTitleInfoId = bookTitleInfoId
        });
        return Ok(BookDetailByTitle);
    }

    [HttpGet]
    [Route("get-damagebyBorrowerList")]
    public async Task<ActionResult> GetDamageByBorrowerListSpRequest(int baseSchoolNameId, string searchText)
    {
        var presentStocks = await _mediator.Send(new GetDamageByBorrowerListSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            SearchText = searchText
        });
        return Ok(presentStocks);
    }

    [HttpGet]
    [Route("get-spGetDamageByBorrowerListbyDateRange")]
    public async Task<ActionResult> GetSpFlyingSchedule(DateTime dateFrom, DateTime dateTo, int baseSchoolNameId)
    {
        var damagebyBorrowerListByDateRange = await _mediator.Send(new GetSpDamageByBorrowerDateRangeRequest
        {
            DateFrom = dateFrom,
            DateTo = dateTo,
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(damagebyBorrowerListByDateRange);
    }

    [HttpGet]
    [Route("get-damagebymemberlist")]
    public async Task<ActionResult> GetDamageByMemberList(int memberInfoId)
    {
        var damageByMemberList = await _mediator.Send(new GetDamageByMemberListSpRequest
        {
            MemberInfoId = memberInfoId,
        });
        return Ok(damageByMemberList);
    }

    [HttpGet]
    [Route("get-bookInformationbytitleformember")]
    public async Task<ActionResult> GetBookInformationListByTitleForMemberBySp(string searchText)
    {
        var bookInfo = await _mediator.Send(new GetBookInformationListByTitleForMemberBySpRequest
        {
            //BaseSchoolNameId = baseSchoolNameId,
            SearchText = searchText
            //BookCategoryId = bookCategoryId
           
        });
        return Ok(bookInfo);
    }

}

