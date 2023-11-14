using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.JobStatus;
using SchoolManagement.Application.Features.JobStatuses.Requests.Commands;
using SchoolManagement.Application.Features.JobStatuses.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.JobStatus)]
[ApiController]
[Authorize]
public class JobStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-JobStatuses")]
    public async Task<ActionResult<List<JobStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var JobStatuss = await _mediator.Send(new GetJobStatusListRequest { QueryParams = queryParams });
        return Ok(JobStatuss);
    }

    

    [HttpGet]
    [Route("get-JobStatusDetail/{id}")]
    public async Task<ActionResult<JobStatusDto>> Get(int id)
    {
        var JobStatus = await _mediator.Send(new GetJobStatusDetailRequest { JobStatusId = id });
        return Ok(JobStatus);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-JobStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateJobStatusDto JobStatus)
    {
        var command = new CreateJobStatusCommand { JobStatusDto = JobStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-JobStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] JobStatusDto JobStatus)
    {
        var command = new UpdateJobStatusCommand { JobStatusDto = JobStatus };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-JobStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteJobStatusCommand { JobStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedJobStatuses")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedJobStatus()
    {
        var selectedJobStatus = await _mediator.Send(new GetSelectedJobStatusRequest { });
        return Ok(selectedJobStatus);
    }
}

