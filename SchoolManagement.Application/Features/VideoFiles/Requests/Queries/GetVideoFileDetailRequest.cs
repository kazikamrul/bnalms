using MediatR;
using SchoolManagement.Application.DTOs.VideoFile;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.VideoFiles.Requests.Queries
{
    public class GetVideoFileDetailRequest : IRequest<VideoFileDto>
    {
        public int VideoFileId { get; set; }
    }
}
