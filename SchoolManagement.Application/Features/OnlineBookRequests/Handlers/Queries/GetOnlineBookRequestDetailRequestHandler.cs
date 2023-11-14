using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OnlineBookRequest;
using SchoolManagement.Application.Features.OnlineBookRequests.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Handlers.Queries
{
    public class GetOnlineBookRequestDetailRequestHandler : IRequestHandler<GetOnlineBookRequestDetailRequest, OnlineBookRequestDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<OnlineBookRequest> _OnlineBookRequestRepository;
        public GetOnlineBookRequestDetailRequestHandler(ISchoolManagementRepository<OnlineBookRequest> OnlineBookRequestRepository, IMapper mapper)
        {
            _OnlineBookRequestRepository = OnlineBookRequestRepository;
            _mapper = mapper;
        }
        public async Task<OnlineBookRequestDto> Handle(GetOnlineBookRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var OnlineBookRequest = await _OnlineBookRequestRepository.Get(request.OnlineBookRequestId);
            return _mapper.Map<OnlineBookRequestDto>(OnlineBookRequest);
        }
    }
}
