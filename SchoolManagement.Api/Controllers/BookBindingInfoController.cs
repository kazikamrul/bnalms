using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BookBindingInfo;
using SchoolManagement.Application.Features.BookBindingInfos.Requests.Commands;
using SchoolManagement.Application.Features.BookBindingInfos.Requests.Queries;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Commands;
using SchoolManagement.Application.Features.Demands.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BookBindingInfo)]
[ApiController]
[Authorize]
public class BookBindingInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookBindingInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-BookBindingInfos")]
    public async Task<ActionResult<List<BookBindingInfoDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BookBindingInfos = await _mediator.Send(new GetBookBindingInfoListRequest { QueryParams = queryParams });
        return Ok(BookBindingInfos);
    }

    

    [HttpGet]
    [Route("get-BookBindingInfoDetail/{id}")]
    public async Task<ActionResult<BookBindingInfoDto>> Get(int id)
    {
        var BookBindingInfo = await _mediator.Send(new GetBookBindingInfoDetailRequest { BookBindingInfoId = id });
        return Ok(BookBindingInfo);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-BookBindingInfo")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBookBindingInfoDto BookBindingInfo)
    {
        var command = new CreateBookBindingInfoCommand { BookBindingInfoDto = BookBindingInfo };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-BookBindingInfo/{id}")]
    public async Task<ActionResult> Put([FromBody] BookBindingInfoDto BookBindingInfo)
    {
        var command = new UpdateBookBindingInfoCommand { BookBindingInfoDto = BookBindingInfo };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-BookBindingInfo/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBookBindingInfoCommand { BookBindingInfoId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBookBindingInfos")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedBookBindingInfo()
    {
        var selectedBookBindingInfo = await _mediator.Send(new GetSelectedBookBindingInfoRequest { });
        return Ok(selectedBookBindingInfo);
    }

    [HttpGet] 
    [Route("get-bookBindingInfoList")]
    public async Task<ActionResult> GetOnlineBookRequestList(int baseSchoolNameId,string searchText)
    {
        var bookBindingInfos = await _mediator.Send(new GetBookBindingInfoListBySpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            SearchText =searchText
        });
        return Ok(bookBindingInfos);
    }
     
    [HttpGet]
    [Route("return-bookbindinginfo")]
    public async Task<ActionResult> ReturnBookBindingInfo(int bookInformationId)
    {
        var returnBookBinding = await _mediator.Send(new ReturnBookBindingCommand
        {
            BookInformationId = bookInformationId
        });
        return Ok(returnBookBinding);
    }
}

