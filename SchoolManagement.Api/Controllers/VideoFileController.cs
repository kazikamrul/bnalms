using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.VideoFile;
using SchoolManagement.Application.Features.VideoFiles.Requests.Commands;
using SchoolManagement.Application.Features.VideoFiles.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.VideoFile)]
[ApiController]
[Authorize]
public class VideoFileController : ControllerBase
{
    private readonly IMediator _mediator;

    public VideoFileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-VideoFiles")]
    public async Task<ActionResult<List<VideoFileDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var VideoFiles = await _mediator.Send(new GetVideoFileListRequest
        {
            QueryParams = queryParams
        });
        return Ok(VideoFiles);
    }

    [HttpGet]
    [Route("get-VideoFileDetail/{id}")]
    public async Task<ActionResult<VideoFileDto>> Get(int id)
    {
        var VideoFile = await _mediator.Send(new GetVideoFileDetailRequest { VideoFileId = id });
        return Ok(VideoFile);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [RequestFormLimits(MultipartBodyLengthLimit = 2147483648)]
    [Route("save-VideoFile")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateVideoFileDto VideoFile)
    {
        var command = new CreateVideoFileCommand { VideoFileDto = VideoFile };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-VideoFile/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateVideoFileDto createVideoFile)
    {
        var command = new UpdateVideoFileCommand { CreateVideoFileDto = createVideoFile };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-VideoFile/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteVideoFileCommand { VideoFileId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    //[HttpGet]
    //[Route("get-selectedVideoFileByMaterialTitleIdBaseSchoolIdAndCourseNameId")]
    //public async Task<ActionResult<List<VideoFileDto>>> GetVideoFilesByMaterialTitleIdBaseSchoolIdAndCourseNameId(int baseSchoolNameId, int courseNameId,int materialTitleId)
    //{ 
    //    var VideoFile = await _mediator.Send(new GetVideoFilesByMaterialTitleIdBaseSchoolIdAndCourseNameIdRequest
    //    {
    //        BaseSchoolNameId = baseSchoolNameId,
    //        VideoFileTitleId = materialTitleId,
    //        CourseNameId = courseNameId
    //    });
    //    return Ok(VideoFile); 
    //}
}

