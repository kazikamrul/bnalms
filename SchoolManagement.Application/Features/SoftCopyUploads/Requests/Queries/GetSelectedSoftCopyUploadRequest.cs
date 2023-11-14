using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.SoftCopyUploads.Requests.Queries
{
    public class GetSelectedSoftCopyUploadRequest : IRequest<List<SelectedModel>>
    {
    }
}
