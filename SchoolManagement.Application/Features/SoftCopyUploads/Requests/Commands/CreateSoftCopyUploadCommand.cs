using MediatR;
using SchoolManagement.Application.DTOs.SoftCopyUpload;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SoftCopyUploads.Requests.Commands
{
    public class CreateSoftCopyUploadCommand : IRequest<BaseCommandResponse>
    {
        public CreateSoftCopyUploadDto SoftCopyUploadDto { get; set; }
    }
}
