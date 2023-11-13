using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.InformationFezups.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InformationFezups.Handlers.Queries
{
    public class GetSelectedInformationFezupRequestHandler : IRequestHandler<GetSelectedInformationFezupRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<InformationFezup> _InformationFezupRepository;


        public GetSelectedInformationFezupRequestHandler(ISchoolManagementRepository<InformationFezup> InformationFezupRepository)
        {
            _InformationFezupRepository = InformationFezupRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedInformationFezupRequest request, CancellationToken cancellationToken)
        {
            ICollection<InformationFezup> codeValues = await _InformationFezupRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.PONo,
                Value = x.InformationFezupId
            }).ToList();
            return selectModels;
        }
    }
}
