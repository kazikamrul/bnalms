using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.FeeInformations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FeeInformations.Handlers.Queries
{
    public class GetSelectedFeeInformationRequestHandler : IRequestHandler<GetSelectedFeeInformationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<FeeInformation> _FeeInformationRepository;


        public GetSelectedFeeInformationRequestHandler(ISchoolManagementRepository<FeeInformation> FeeInformationRepository)
        {
            _FeeInformationRepository = FeeInformationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedFeeInformationRequest request, CancellationToken cancellationToken)
        {
            ICollection<FeeInformation> codeValues = await _FeeInformationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ReceivedAmount,
                Value = x.FeeInformationId
            }).ToList();
            return selectModels;
        }
    }
}
