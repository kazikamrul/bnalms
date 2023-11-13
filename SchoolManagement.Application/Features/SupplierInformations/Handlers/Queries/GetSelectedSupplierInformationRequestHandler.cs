using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SupplierInformations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SupplierInformations.Handlers.Queries
{
    public class GetSelectedSupplierInformationRequestHandler : IRequestHandler<GetSelectedSupplierInformationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SupplierInformation> _SupplierInformationRepository;


        public GetSelectedSupplierInformationRequestHandler(ISchoolManagementRepository<SupplierInformation> SupplierInformationRepository)
        {
            _SupplierInformationRepository = SupplierInformationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSupplierInformationRequest request, CancellationToken cancellationToken)
        {
            ICollection<SupplierInformation> codeValues = await _SupplierInformationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.SupplierName,
                Value = x.SupplierInformationId
            }).ToList();
            return selectModels;
        }
    }
}
