using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MemberRegistrations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MemberRegistrations.Handlers.Queries
{
    public class GetSelectedMemberRegistrationRequestHandler : IRequestHandler<GetSelectedMemberRegistrationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MemberRegistration> _MemberRegistrationRepository;


        public GetSelectedMemberRegistrationRequestHandler(ISchoolManagementRepository<MemberRegistration> MemberRegistrationRepository)
        {
            _MemberRegistrationRepository = MemberRegistrationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMemberRegistrationRequest request, CancellationToken cancellationToken)
        {
            ICollection<MemberRegistration> codeValues = await _MemberRegistrationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.MemberName,
                Value = x.MemberRegistrationId
            }).ToList();
            return selectModels;
        }
    }
}
