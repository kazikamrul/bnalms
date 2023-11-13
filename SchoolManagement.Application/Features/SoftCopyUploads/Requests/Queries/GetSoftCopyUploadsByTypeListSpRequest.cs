using MediatR;

namespace SchoolManagement.Application.Features.SoftCopyUploads.Requests.Queries
{
    public class GetSoftCopyUploadsByTypeListSpRequest : IRequest<object>
    {
        public int DocumentTypeId { get; set; }
    }
}
 