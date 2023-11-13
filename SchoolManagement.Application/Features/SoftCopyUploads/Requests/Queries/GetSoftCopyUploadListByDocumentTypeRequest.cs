using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.SoftCopyUpload;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SoftCopyUploads.Requests.Queries
{
    public class GetSoftCopyUploadListByDocumentTypeRequest : IRequest<PagedResult<SoftCopyUploadDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int BaseSchoolNameId { get; set; }
        public int DocumentTypeId { get; set; }
    }
} 
 