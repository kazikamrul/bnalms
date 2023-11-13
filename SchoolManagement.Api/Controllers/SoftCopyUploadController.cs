using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SoftCopyUpload;
using SchoolManagement.Application.Features.SoftCopyUploads.Requests.Commands;
using SchoolManagement.Application.Features.SoftCopyUploads.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SoftCopyUpload)]
[ApiController]
[Authorize]
public class SoftCopyUploadController : ControllerBase
{
    private readonly IMediator _mediator;

    public SoftCopyUploadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-SoftCopyUploads")]
    public async Task<ActionResult<List<SoftCopyUploadDto>>> Get([FromQuery] QueryParams queryParams,int baseSchoolNameId)
    {
        var SoftCopyUploads = await _mediator.Send(new GetSoftCopyUploadListRequest
        {
            QueryParams = queryParams,
            BaseSchoolNameId =baseSchoolNameId
        });
        return Ok(SoftCopyUploads);
    }

    [HttpGet]
    [Route("get-SoftCopyUploadsByDocumentType")]
    public async Task<ActionResult<List<SoftCopyUploadDto>>> GetSoftCopyUpload([FromQuery] QueryParams queryParams, int baseSchoolNameId,int documentTypeId)
    {
        var SoftCopyUploads = await _mediator.Send(new GetSoftCopyUploadListByDocumentTypeRequest
        {
            QueryParams = queryParams,
            BaseSchoolNameId = baseSchoolNameId,
            DocumentTypeId =documentTypeId
        });
        return Ok(SoftCopyUploads);
    }



    [HttpGet]
    [Route("get-SoftCopyUploadDetail/{id}")]
    public async Task<ActionResult<SoftCopyUploadDto>> Get(int id)
    {
        var SoftCopyUpload = await _mediator.Send(new GetSoftCopyUploadDetailRequest { SoftCopyUploadId = id });
        return Ok(SoftCopyUpload);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [RequestFormLimits(MultipartBodyLengthLimit = 2147483648)]
    [Route("save-SoftCopyUpload")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateSoftCopyUploadDto SoftCopyUpload)
    {
        var command = new CreateSoftCopyUploadCommand { SoftCopyUploadDto = SoftCopyUpload };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-SoftCopyUpload/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateSoftCopyUploadDto SoftCopyUpload)
    {
        var command = new UpdateSoftCopyUploadCommand { CreateSoftCopyUploadDto = SoftCopyUpload };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-SoftCopyUpload/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSoftCopyUploadCommand { SoftCopyUploadId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedSoftCopyUploads")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedSoftCopyUpload()
    {
        var selectedSoftCopyUpload = await _mediator.Send(new GetSelectedSoftCopyUploadRequest { });
        return Ok(selectedSoftCopyUpload);
    }
}

