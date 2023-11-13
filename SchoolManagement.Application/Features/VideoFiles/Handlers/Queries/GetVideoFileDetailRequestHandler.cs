using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.VideoFile;
using SchoolManagement.Application.Features.VideoFiles.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.VideoFiles.Handlers.Queries
{
    public class GetVideoFileDetailRequestHandler : IRequestHandler<GetVideoFileDetailRequest, VideoFileDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<VideoFile> _VideoFileRepository;
        public GetVideoFileDetailRequestHandler(ISchoolManagementRepository<VideoFile> VideoFileRepository, IMapper mapper)
        {
            _VideoFileRepository = VideoFileRepository;
            _mapper = mapper;
        }
        public async Task<VideoFileDto> Handle(GetVideoFileDetailRequest request, CancellationToken cancellationToken)
        {
            var VideoFile = await _VideoFileRepository.Get(request.VideoFileId);
            return _mapper.Map<VideoFileDto>(VideoFile);
        }
    }
}
