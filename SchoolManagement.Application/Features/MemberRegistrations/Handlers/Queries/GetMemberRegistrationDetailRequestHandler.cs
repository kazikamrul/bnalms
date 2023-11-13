using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MemberRegistration;
using SchoolManagement.Application.Features.MemberRegistrations.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MemberRegistrations.Handlers.Queries
{
    public class GetMemberRegistrationDetailRequestHandler : IRequestHandler<GetMemberRegistrationDetailRequest, MemberRegistrationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<MemberRegistration> _MemberRegistrationRepository;
        public GetMemberRegistrationDetailRequestHandler(ISchoolManagementRepository<MemberRegistration> MemberRegistrationRepository, IMapper mapper)
        {
            _MemberRegistrationRepository = MemberRegistrationRepository;
            _mapper = mapper;
        }
        public async Task<MemberRegistrationDto> Handle(GetMemberRegistrationDetailRequest request, CancellationToken cancellationToken)
        {
            var MemberRegistration = await _MemberRegistrationRepository.Get(request.MemberRegistrationId);
            return _mapper.Map<MemberRegistrationDto>(MemberRegistration);
        }
    }
}
