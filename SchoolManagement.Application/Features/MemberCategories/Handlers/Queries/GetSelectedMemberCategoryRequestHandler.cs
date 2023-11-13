using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MemberCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MemberCategorys.Handlers.Queries
{
    public class GetSelectedMemberCategoryRequestHandler : IRequestHandler<GetSelectedMemberCategoryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MemberCategory> _MemberCategoryRepository;


        public GetSelectedMemberCategoryRequestHandler(ISchoolManagementRepository<MemberCategory> MemberCategoryRepository)
        {
            _MemberCategoryRepository = MemberCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMemberCategoryRequest request, CancellationToken cancellationToken)
        {
            ICollection<MemberCategory> codeValues = await _MemberCategoryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.MemberCategoryName,
                Value = x.MemberCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
