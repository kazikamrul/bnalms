using MediatR;

namespace SchoolManagement.Application.Features.VideoFiles.Requests.Commands
{
    public class DeleteVideoFileCommand : IRequest
    {
        public int VideoFileId { get; set; }
    }
}
