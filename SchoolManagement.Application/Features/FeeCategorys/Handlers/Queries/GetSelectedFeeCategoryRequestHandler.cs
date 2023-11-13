using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.FeeCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FeeCategorys.Handlers.Queries
{
    public class GetSelectedFeeCategoryRequestHandler : IRequestHandler<GetSelectedFeeCategoryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<FeeCategory> _FeeCategoryRepository;


        public GetSelectedFeeCategoryRequestHandler(ISchoolManagementRepository<FeeCategory> FeeCategoryRepository)
        {
            _FeeCategoryRepository = FeeCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedFeeCategoryRequest request, CancellationToken cancellationToken)
        {
            ICollection<FeeCategory> codeValues = await _FeeCategoryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.FeeCategoryName,
                Value = x.FeeCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
