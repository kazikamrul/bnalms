using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MemberInfo;
using SchoolManagement.Application.Features.MemberInfos.Requests.Commands;
using SchoolManagement.Application.Features.MemberInfos.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MemberInfo)]
[ApiController]
[Authorize]
public class MemberInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public MemberInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-MemberInfos")]
    public async Task<ActionResult<List<MemberInfoDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MemberInfos = await _mediator.Send(new GetMemberInfoListRequest { QueryParams = queryParams });
        return Ok(MemberInfos);
    }

    [HttpGet]
    [Route("get-memberListForUserCreate")]
    public async Task<ActionResult> GetMemberListForUserCreate(string pno)
    {
        var proceduredTrainee = await _mediator.Send(new GetMemberListForUserCreateRequest
        {
            Pno = pno
        });
        return Ok(proceduredTrainee);
    }


    [HttpGet]
    [Route("get-MemberInfoDetail/{id}")]
    public async Task<ActionResult<MemberInfoDto>> Get(int id)
    {
        var MemberInfo = await _mediator.Send(new GetMemberInfoDetailRequest { MemberInfoId = id });
        return Ok(MemberInfo);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-MemberInfo")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateMemberInfoDto MemberInfo)
    {
        var command = new CreateMemberInfoCommand { MemberInfoDto = MemberInfo };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-MemberInfo/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateMemberInfoDto MemberInfo)
    {
        var command = new UpdateMemberInfoCommand { CreateMemberInfoDto = MemberInfo };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-MemberInfo/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMemberInfoCommand { MemberInfoId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedMemberInfos")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedMemberInfo()
    {
        var selectedMemberInfo = await _mediator.Send(new GetSelectedMemberInfoRequest { });
        return Ok(selectedMemberInfo);
    }
    [HttpGet]
    [Route("get-autocompletePno")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompletePno(string pno)
    {
        var course = await _mediator.Send(new GetAutoCompletePNoRequest
        {
            Pno = pno,
        });
        return Ok(course);
    }
    [HttpGet]
    [Route("get-memberNameByIdRequest")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMemberName(int memberInfoId)
    {
        var itemName = await _mediator.Send(new GetMemberNameByIdRequest
        {
            MemberInfoId = memberInfoId
        });
        return Ok(itemName);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("active-memberInfo/{id}")]
    public async Task<ActionResult> AcceptMeaSquadronState(int id)
    {
        var command = new ActiveMemberInfoCommand { MemberInfoId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("inActive-memberInfo/{id}")]
    public async Task<ActionResult> CalcelMeaSquadronState(int id)
    {
        var command = new InActiveMemberInfoCommand { MemberInfoId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-memberInformationListByDepartmentId")]
    public async Task<ActionResult> GetMemberInformationListByDepartmentId(int baseSchoolNameId)
    {
        var equipmentName = await _mediator.Send(new GetMemberInformationListByDepartmentIdRequest
        {
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(equipmentName);
    }
}

