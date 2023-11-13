using MediatR;
using SchoolManagement.Application.DTOs.SoftCopyUpload;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SoftCopyUploads.Requests.Commands
{
    public class UpdateSoftCopyUploadCommand : IRequest<Unit>
    {
        public CreateSoftCopyUploadDto CreateSoftCopyUploadDto { get; set; }
    }
}
