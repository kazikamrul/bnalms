using MediatR;
using SchoolManagement.Application.DTOs.SoftCopyUpload;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SoftCopyUploads.Requests.Queries
{
    public class GetSoftCopyUploadDetailRequest : IRequest<SoftCopyUploadDto>
    {
        public int SoftCopyUploadId { get; set; }
    }
}
