using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.SoftCopyUpload;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SoftCopyUploads.Requests.Queries
{
    public class GetSoftCopyUploadListRequest : IRequest<PagedResult<SoftCopyUploadDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int BaseSchoolNameId { get; set; }
    }
}
