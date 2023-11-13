using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.OnlineChat;
using SchoolManagement.Application.Features.OnlineChats.Requests.Commands;
using SchoolManagement.Application.Features.OnlineChats.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.OnlineChat)]
[ApiController]
[Authorize]
public class OnlineChatController : ControllerBase
{
    private readonly IMediator _mediator;

    public OnlineChatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-OnlineChats")]
    public async Task<ActionResult<List<OnlineChatDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var OnlineChats = await _mediator.Send(new GetOnlineChatListRequest { QueryParams = queryParams });
        return Ok(OnlineChats);
    }

    

    [HttpGet]
    [Route("get-OnlineChatDetail/{id}")]
    public async Task<ActionResult<OnlineChatDto>> Get(int id)
    {
        var OnlineChat = await _mediator.Send(new GetOnlineChatDetailRequest { OnlineChatId = id });
        return Ok(OnlineChat);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-OnlineChat")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateOnlineChatDto OnlineChat)
    {
        var command = new CreateOnlineChatCommand { OnlineChatDto = OnlineChat };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-OnlineChat/{id}")]
    public async Task<ActionResult> Put([FromBody] OnlineChatDto OnlineChat)
    {
        var command = new UpdateOnlineChatCommand { OnlineChatDto = OnlineChat };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-OnlineChat/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteOnlineChatCommand { OnlineChatId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedOnlineChats")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedOnlineChat()
    {
        var OnlineChat = await _mediator.Send(new GetSelectedOnlineChatRequest { });
        return Ok(OnlineChat);
    }


    [HttpGet]
    [Route("get-OnlineChatsById")]
    public async Task<ActionResult<List<OnlineChatDto>>>  GetOnlineChatsById(string userRole, int senderId, int reciverId)
    {
        var OnlineChats = await _mediator.Send(new GetOnlineChatsByIdRequest {
            UserRole= userRole,
            SenderId= senderId,
            ReciverId= reciverId
        });
        return Ok(OnlineChats);
    }


    [HttpGet]
    [Route("get-OnlineChatResponselistForSchool")]
    public async Task<ActionResult> GetOnlineChatResponselistForSchool(int id)
    {
        var OnlineChats = await _mediator.Send(new GetOnlineChatResponseListForSchoolBySpRequest
        {
            BaseSchoolNameId = id
        });
        return Ok(OnlineChats);
    }


    [HttpGet]
    [Route("get-OnlineChatReminderForAdmin")]
    public async Task<ActionResult> GetOnlineChatReminderForAdmin(int id, string userRole)
    {
        var OnlineChats = await _mediator.Send(new GetOnlineChatReminderForAdminBySpRequest
        {
            BaseSchoolNameId = id,
            UserRole = userRole
        });
        return Ok(OnlineChats);
    }

    [HttpGet]
    [Route("get-OnlineChatDashboardCount")]
    public async Task<ActionResult> GetOnlineChatDashboardCount(int id, string userRole)
    {
        var OnlineChats = await _mediator.Send(new GetOnlineChatDashboardCountBySpRequest
        {
            BaseSchoolNameId = id,
            UserRole = userRole
        });
        return Ok(OnlineChats);
    }



    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("change-recieverSeenStatus")]
    public async Task<ActionResult> ChangeRecieverSeenStatus(int OnlineChatId, int Status)
    {
        var command = new ChangeSeenStatusCommand
        {
            OnlineChatId = OnlineChatId,
            Status = Status
        };
        await _mediator.Send(command);
        return NoContent();
    }

}

