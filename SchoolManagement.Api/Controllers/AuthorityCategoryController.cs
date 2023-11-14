using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.AuthorityCategory;
using SchoolManagement.Application.Features.AuthorityCategorys.Requests.Commands;
using SchoolManagement.Application.Features.AuthorityCategorys.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.AuthorityCategory)]
[ApiController]
[Authorize]
public class AuthorityCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorityCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-AuthorityCategories")]
    public async Task<ActionResult<List<AuthorityCategoryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var AuthorityCategorys = await _mediator.Send(new GetAuthorityCategoryListRequest { QueryParams = queryParams });
        return Ok(AuthorityCategorys);
    }

    

    [HttpGet]
    [Route("get-AuthorityCategoryDetail/{id}")]
    public async Task<ActionResult<AuthorityCategoryDto>> Get(int id)
    {
        var AuthorityCategory = await _mediator.Send(new GetAuthorityCategoryDetailRequest { AuthorityCategoryId = id });
        return Ok(AuthorityCategory);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-AuthorityCategory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAuthorityCategoryDto AuthorityCategory)
    {
        var command = new CreateAuthorityCategoryCommand { AuthorityCategoryDto = AuthorityCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-AuthorityCategory/{id}")]
    public async Task<ActionResult> Put([FromBody] AuthorityCategoryDto AuthorityCategory)
    {
        var command = new UpdateAuthorityCategoryCommand { AuthorityCategoryDto = AuthorityCategory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-AuthorityCategory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAuthorityCategoryCommand { AuthorityCategoryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedAuthorityCategories")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedAuthorityCategory()
    {
        var selectedAuthorityCategory = await _mediator.Send(new GetSelectedAuthorityCategoryRequest { });
        return Ok(selectedAuthorityCategory);
    }
}

