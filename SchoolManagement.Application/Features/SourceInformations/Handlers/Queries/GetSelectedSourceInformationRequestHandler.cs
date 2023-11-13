using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SourceInformations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SourceInformations.Handlers.Queries
{
    public class GetSelectedSourceInformationRequestHandler : IRequestHandler<GetSelectedSourceInformationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SourceInformation> _SourceInformationRepository;


        public GetSelectedSourceInformationRequestHandler(ISchoolManagementRepository<SourceInformation> SourceInformationRepository)
        {
            _SourceInformationRepository = SourceInformationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSourceInformationRequest request, CancellationToken cancellationToken)
        {
            ICollection<SourceInformation> codeValues = await _SourceInformationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.SourceName,
                Value = x.SourceInformationId
            }).ToList();
            return selectModels;
        }
    }
}
