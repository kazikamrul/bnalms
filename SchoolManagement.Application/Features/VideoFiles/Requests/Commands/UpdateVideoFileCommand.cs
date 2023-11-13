using SchoolManagement.Application.DTOs.VideoFile;
using MediatR;

namespace SchoolManagement.Application.Features.VideoFiles.Requests.Commands
{
    public class UpdateVideoFileCommand : IRequest<Unit>
    {
        public CreateVideoFileDto CreateVideoFileDto { get; set; }

    }
}
