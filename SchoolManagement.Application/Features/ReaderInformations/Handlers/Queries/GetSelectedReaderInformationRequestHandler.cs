using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ReaderInformations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReaderInformations.Handlers.Queries
{
    public class GetSelectedReaderInformationRequestHandler : IRequestHandler<GetSelectedReaderInformationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ReaderInformation> _ReaderInformationRepository;


        public GetSelectedReaderInformationRequestHandler(ISchoolManagementRepository<ReaderInformation> ReaderInformationRepository)
        {
            _ReaderInformationRepository = ReaderInformationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedReaderInformationRequest request, CancellationToken cancellationToken)
        {
            ICollection<ReaderInformation> codeValues = await _ReaderInformationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ReaderName,
                Value = x.ReaderInformationId
            }).ToList();
            return selectModels;
        }
    }
}
