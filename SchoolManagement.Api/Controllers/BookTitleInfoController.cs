using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BookTitleInfo;
using SchoolManagement.Application.Features.BookTitleInfos.Requests.Commands;
using SchoolManagement.Application.Features.BookTitleInfos.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BookTitleInfo)]
[ApiController]
[Authorize]
public class BookTitleInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookTitleInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-BookTitleInfos")]
    public async Task<ActionResult<List<BookTitleInfoDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BookTitleInfos = await _mediator.Send(new GetBookTitleInfoListRequest { QueryParams = queryParams });
        return Ok(BookTitleInfos);
    }

    

    [HttpGet]
    [Route("get-BookTitleInfoDetail/{id}")]
    public async Task<ActionResult<BookTitleInfoDto>> Get(int id)
    {
        var BookTitleInfo = await _mediator.Send(new GetBookTitleInfoDetailRequest { BookTitleInfoId = id });
        return Ok(BookTitleInfo);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-BookTitleInfo")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBookTitleInfoDto BookTitleInfo)
    {
        var command = new CreateBookTitleInfoCommand { BookTitleInfoDto = BookTitleInfo };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-BookTitleInfo/{id}")]
    public async Task<ActionResult> Put([FromBody] BookTitleInfoDto BookTitleInfo)
    {
        var command = new UpdateBookTitleInfoCommand { BookTitleInfoDto = BookTitleInfo };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-BookTitleInfo/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBookTitleInfoCommand { BookTitleInfoId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBookTitleInfos")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedBookTitleInfo()
    {
        var selectedBookTitleInfo = await _mediator.Send(new GetSelectedBookTitleInfoRequest { });
        return Ok(selectedBookTitleInfo);
    }

    [HttpGet]
    [Route("get-autocompleteBookTitle")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompleteBookTitle(string title)
    {
        var course = await _mediator.Send(new GetAutoCompleteBookTitleRequest
        {
            Title = title,
        });
        return Ok(course);
    }
    [HttpGet]
    [Route("get-autocompleteBookTitleName")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompleteBookTitleName(string title)
    {
        var course = await _mediator.Send(new GetAutoCompleteBookTitleNameRequest
        {
            Title = title,
        });
        return Ok(course);
    }
}

