using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.VideoFiles.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.VideoFiles.Handlers.Commands
{
    public class DeleteVideoFileCommandHandler : IRequestHandler<DeleteVideoFileCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteVideoFileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteVideoFileCommand request, CancellationToken cancellationToken)
        {
            var VideoFiles = await _unitOfWork.Repository<VideoFile>().Get(request.VideoFileId);

            if (VideoFiles == null)
                throw new NotFoundException(nameof(VideoFile), request.VideoFileId);

            await _unitOfWork.Repository<VideoFile>().Delete(VideoFiles);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
