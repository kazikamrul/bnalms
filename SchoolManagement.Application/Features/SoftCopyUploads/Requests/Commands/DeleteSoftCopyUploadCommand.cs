using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SoftCopyUploads.Requests.Commands
{
    public class DeleteSoftCopyUploadCommand : IRequest
    {
        public int SoftCopyUploadId { get; set; }
    }
}
