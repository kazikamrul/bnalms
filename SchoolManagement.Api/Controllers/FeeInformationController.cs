using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.FeeInformation;
using SchoolManagement.Application.Features.FeeInformations.Requests.Commands;
using SchoolManagement.Application.Features.FeeInformations.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.FeeInformation)]
[ApiController]
[Authorize]
public class FeeInformationController : ControllerBase
{
    private readonly IMediator _mediator;

    public FeeInformationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-FeeInformations")]
    public async Task<ActionResult<List<FeeInformationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var FeeInformations = await _mediator.Send(new GetFeeInformationListRequest { QueryParams = queryParams });
        return Ok(FeeInformations);
    }

    

    [HttpGet]
    [Route("get-FeeInformationDetail/{id}")]
    public async Task<ActionResult<FeeInformationDto>> Get(int id)
    {
        var FeeInformation = await _mediator.Send(new GetFeeInformationDetailRequest { FeeInformationId = id });
        return Ok(FeeInformation);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-FeeInformation")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateFeeInformationDto FeeInformation)
    {
        var command = new CreateFeeInformationCommand { FeeInformationDto = FeeInformation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-FeeInformation/{id}")]
    public async Task<ActionResult> Put([FromBody] FeeInformationDto FeeInformation)
    {
        var command = new UpdateFeeInformationCommand { FeeInformationDto = FeeInformation };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-FeeInformation/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteFeeInformationCommand { FeeInformationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedFeeInformations")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedFeeInformation()
    {
        var selectedFeeInformation = await _mediator.Send(new GetSelectedFeeInformationRequest { });
        return Ok(selectedFeeInformation);
    }
    [HttpGet]
    [Route("get-feeInformationListByPno")]
    public async Task<ActionResult> GetFeeInformationListByPno(int memberInfoId)
    {
        var equipmentName = await _mediator.Send(new GetFeeInformationListByPnoRequest
        {
            MemberInfoId = memberInfoId
        });
        return Ok(equipmentName);
    }
}

