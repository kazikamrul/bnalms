using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Bulletin;
using SchoolManagement.Application.Features.Bulletins.Requests.Commands;
using SchoolManagement.Application.Features.Bulletins.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Bulletin)]
[ApiController]
[Authorize]
public class BulletinController : ControllerBase
{
    private readonly IMediator _mediator;

    public BulletinController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Bulletins")]
    public async Task<ActionResult<List<BulletinDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Bulletins = await _mediator.Send(new GetBulletinListRequest { QueryParams = queryParams });
        return Ok(Bulletins);
    }

    

    [HttpGet]
    [Route("get-BulletinDetail/{id}")]
    public async Task<ActionResult<BulletinDto>> Get(int id)
    {
        var Bulletin = await _mediator.Send(new GetBulletinDetailRequest { BulletinId = id });
        return Ok(Bulletin);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Bulletin")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBulletinDto Bulletin)
    {
        var command = new CreateBulletinCommand { BulletinDto = Bulletin };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Bulletin/{id}")]
    public async Task<ActionResult> Put([FromBody] BulletinDto Bulletin)
    {
        var command = new UpdateBulletinCommand { BulletinDto = Bulletin };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Bulletin/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBulletinCommand { BulletinId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBulletins")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedBulletin()
    {
        var selectedBulletin = await _mediator.Send(new GetSelectedBulletinRequest { });
        return Ok(selectedBulletin);
    }
    [HttpGet]
    [Route("get-spBulletinList")]
    public async Task<ActionResult> GetActiveBulletinList(int memberInfoId)
    {
        var bulletinList = await _mediator.Send(new GetBulletinListBySpRequest
        {
            MemberInfoId = memberInfoId
        });
        return Ok(bulletinList);
    }
    [HttpGet]
    [Route("get-spBulletinListByLibrary")]
    public async Task<ActionResult> GetActiveBulletinListByLibrary(int baseSchoolNameId)
    {
        var bulletinList = await _mediator.Send(new GetBulletinListByLibrarySpRequest
        {
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(bulletinList);
    }
}

