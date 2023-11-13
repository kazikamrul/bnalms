using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.LibraryAuthoritys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.LibraryAuthoritys.Handlers.Queries
{
    public class GetSelectedLibraryAuthorityRequestHandler : IRequestHandler<GetSelectedLibraryAuthorityRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<LibraryAuthority> _LibraryAuthorityRepository;


        public GetSelectedLibraryAuthorityRequestHandler(ISchoolManagementRepository<LibraryAuthority> LibraryAuthorityRepository)
        {
            _LibraryAuthorityRepository = LibraryAuthorityRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedLibraryAuthorityRequest request, CancellationToken cancellationToken)
        {
            ICollection<LibraryAuthority> codeValues = await _LibraryAuthorityRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.LibraryAuthorityId
            }).ToList();
            return selectModels;
        }
    }
}
