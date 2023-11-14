using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AuthorityCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.AuthorityCategorys.Handlers.Queries
{
    public class GetSelectedAuthorityCategoryRequestHandler : IRequestHandler<GetSelectedAuthorityCategoryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<AuthorityCategory> _AuthorityCategoryRepository;


        public GetSelectedAuthorityCategoryRequestHandler(ISchoolManagementRepository<AuthorityCategory> AuthorityCategoryRepository)
        {
            _AuthorityCategoryRepository = AuthorityCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAuthorityCategoryRequest request, CancellationToken cancellationToken)
        {
            ICollection<AuthorityCategory> codeValues = await _AuthorityCategoryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.AuthorCategoryName,
                Value = x.AuthorityCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
