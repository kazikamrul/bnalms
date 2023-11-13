using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.VideoFile;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.VideoFiles.Requests.Queries
{
    public class GetVideoFileListRequest : IRequest<PagedResult<VideoFileDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
