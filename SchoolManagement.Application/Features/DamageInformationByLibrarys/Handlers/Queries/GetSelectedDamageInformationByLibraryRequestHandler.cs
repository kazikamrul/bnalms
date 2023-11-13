using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DamageInformationByLibrarys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DamageInformationByLibrarys.Handlers.Queries
{
    public class GetSelectedDamageInformationByLibraryRequestHandler : IRequestHandler<GetSelectedDamageInformationByLibraryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DamageInformationByLibrary> _DamageInformationByLibraryRepository;


        public GetSelectedDamageInformationByLibraryRequestHandler(ISchoolManagementRepository<DamageInformationByLibrary> DamageInformationByLibraryRepository)
        {
            _DamageInformationByLibraryRepository = DamageInformationByLibraryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDamageInformationByLibraryRequest request, CancellationToken cancellationToken)
        {
            ICollection<DamageInformationByLibrary> codeValues = await _DamageInformationByLibraryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.DamageBy,
                Value = x.DamageInformationByLibraryId
            }).ToList();
            return selectModels;
        }
    }
}
