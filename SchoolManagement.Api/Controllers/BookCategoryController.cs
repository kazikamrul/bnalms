using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BookCategory;
using SchoolManagement.Application.Features.BookCategorys.Requests.Commands;
using SchoolManagement.Application.Features.BookCategorys.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BookCategory)]
[ApiController]
[Authorize]
public class BookCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-BookCategories")]
    public async Task<ActionResult<List<BookCategoryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BookCategorys = await _mediator.Send(new GetBookCategoryListRequest { QueryParams = queryParams });
        return Ok(BookCategorys);
    }

    

    [HttpGet]
    [Route("get-BookCategoryDetail/{id}")]
    public async Task<ActionResult<BookCategoryDto>> Get(int id)
    {
        var BookCategory = await _mediator.Send(new GetBookCategoryDetailRequest { BookCategoryId = id });
        return Ok(BookCategory);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-BookCategory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBookCategoryDto BookCategory)
    {
        var command = new CreateBookCategoryCommand { BookCategoryDto = BookCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-BookCategory/{id}")]
    public async Task<ActionResult> Put([FromBody] BookCategoryDto BookCategory)
    {
        var command = new UpdateBookCategoryCommand { BookCategoryDto = BookCategory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-BookCategory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBookCategoryCommand { BookCategoryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBookCategories")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedBookCategory()
    {
        var selectedBookCategory = await _mediator.Send(new GetSelectedBookCategoryRequest { });
        return Ok(selectedBookCategory);
    }

    [HttpGet]
    [Route("get-allBookCategoriesList")]
    public async Task<ActionResult<List<BookCategoryDto>>> getAllBookCategories()
    {
        var bookCategories = await _mediator.Send(new GetAllBookCategoriesListRequest { });
        return Ok(bookCategories);
    }
}

