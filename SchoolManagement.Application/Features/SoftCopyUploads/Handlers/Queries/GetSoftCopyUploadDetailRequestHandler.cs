using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SoftCopyUpload;
using SchoolManagement.Application.Features.SoftCopyUploads.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SoftCopyUploads.Handlers.Queries
{
    public class GetSoftCopyUploadDetailRequestHandler : IRequestHandler<GetSoftCopyUploadDetailRequest, SoftCopyUploadDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SoftCopyUpload> _SoftCopyUploadRepository;
        public GetSoftCopyUploadDetailRequestHandler(ISchoolManagementRepository<SoftCopyUpload> SoftCopyUploadRepository, IMapper mapper)
        {
            _SoftCopyUploadRepository = SoftCopyUploadRepository;
            _mapper = mapper;
        }
        public async Task<SoftCopyUploadDto> Handle(GetSoftCopyUploadDetailRequest request, CancellationToken cancellationToken)
        {
            var SoftCopyUpload = await _SoftCopyUploadRepository.Get(request.SoftCopyUploadId);
            return _mapper.Map<SoftCopyUploadDto>(SoftCopyUpload);
        }
    }
}
