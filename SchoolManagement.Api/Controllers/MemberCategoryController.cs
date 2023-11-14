using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MemberCategory;
using SchoolManagement.Application.Features.MemberCategorys.Requests.Commands;
using SchoolManagement.Application.Features.MemberCategorys.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MemberCategory)]
[ApiController]
[Authorize]
public class MemberCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public MemberCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-memberCategories")]
    public async Task<ActionResult<List<MemberCategoryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MemberCategorys = await _mediator.Send(new GetMemberCategoryListRequest { QueryParams = queryParams });
        return Ok(MemberCategorys);
    }

    

    [HttpGet]
    [Route("get-memberCategoryDetail/{id}")]
    public async Task<ActionResult<MemberCategoryDto>> Get(int id)
    {
        var MemberCategory = await _mediator.Send(new GetMemberCategoryDetailRequest { MemberCategoryId = id });
        return Ok(MemberCategory);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-memberCategory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMemberCategoryDto MemberCategory)
    {
        var command = new CreateMemberCategoryCommand { MemberCategoryDto = MemberCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-memberCategory/{id}")]
    public async Task<ActionResult> Put([FromBody] MemberCategoryDto MemberCategory)
    {
        var command = new UpdateMemberCategoryCommand { MemberCategoryDto = MemberCategory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-memberCategory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMemberCategoryCommand { MemberCategoryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedMemberCategories")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedMemberCategory()
    {
        var selectedMemberCategory = await _mediator.Send(new GetSelectedMemberCategoryRequest { });
        return Ok(selectedMemberCategory);
    }
}

