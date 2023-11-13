using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.FeeCategory;
using SchoolManagement.Application.Features.FeeCategorys.Requests.Commands;
using SchoolManagement.Application.Features.FeeCategorys.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.FeeCategory)]
[ApiController]
[Authorize]
public class FeeCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public FeeCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-FeeCategories")]
    public async Task<ActionResult<List<FeeCategoryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var FeeCategorys = await _mediator.Send(new GetFeeCategoryListRequest { QueryParams = queryParams });
        return Ok(FeeCategorys);
    }

    

    [HttpGet]
    [Route("get-FeeCategoryDetail/{id}")]
    public async Task<ActionResult<FeeCategoryDto>> Get(int id)
    {
        var FeeCategory = await _mediator.Send(new GetFeeCategoryDetailRequest { FeeCategoryId = id });
        return Ok(FeeCategory);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-FeeCategory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateFeeCategoryDto FeeCategory)
    {
        var command = new CreateFeeCategoryCommand { FeeCategoryDto = FeeCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-FeeCategory/{id}")]
    public async Task<ActionResult> Put([FromBody] FeeCategoryDto FeeCategory)
    {
        var command = new UpdateFeeCategoryCommand { FeeCategoryDto = FeeCategory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-FeeCategory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteFeeCategoryCommand { FeeCategoryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedFeeCategories")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedFeeCategory()
    {
        var selectedFeeCategory = await _mediator.Send(new GetSelectedFeeCategoryRequest { });
        return Ok(selectedFeeCategory);
    }
}

