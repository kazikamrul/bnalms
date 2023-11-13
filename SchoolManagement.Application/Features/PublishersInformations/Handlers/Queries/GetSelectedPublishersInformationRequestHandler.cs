using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.PublishersInformations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PublishersInformations.Handlers.Queries
{
    public class GetSelectedPublishersInformationRequestHandler : IRequestHandler<GetSelectedPublishersInformationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<PublishersInformation> _PublishersInformationRepository;


        public GetSelectedPublishersInformationRequestHandler(ISchoolManagementRepository<PublishersInformation> PublishersInformationRepository)
        {
            _PublishersInformationRepository = PublishersInformationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPublishersInformationRequest request, CancellationToken cancellationToken)
        {
            ICollection<PublishersInformation> codeValues = await _PublishersInformationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.PublishersName,
                Value = x.PublishersInformationId
            }).ToList();
            return selectModels;
        }
    }
}
