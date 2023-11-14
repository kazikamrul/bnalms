using SchoolManagement.Application.Responses;
using MediatR;
using SchoolManagement.Application.DTOs.VideoFile;

namespace SchoolManagement.Application.Features.VideoFiles.Requests.Commands
{
    public class CreateVideoFileCommand : IRequest<BaseCommandResponse>
    {
        public CreateVideoFileDto VideoFileDto { get; set; }

    }
}
