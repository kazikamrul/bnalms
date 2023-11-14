using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookInformations.Handlers.Queries
{
    public class GetAutoCompleteAccessionNoByDeptRequestHandler : IRequestHandler<GetAutoCompleteAccessionNoByDeptRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BookInformation> _BookInformationRepository; 
        public GetAutoCompleteAccessionNoByDeptRequestHandler(ISchoolManagementRepository<BookInformation> BookInformationRepository)
        {
            _BookInformationRepository = BookInformationRepository;
        }
          
        public async Task<List<SelectedModel>> Handle(GetAutoCompleteAccessionNoByDeptRequest request, CancellationToken cancellationToken)
        {
                ICollection<BookInformation> traineeBioDataGeneralInfos = await _BookInformationRepository.FilterAsync(x => x.MergeId.Contains(request.accessionNo) && x.BaseSchoolNameId == request.DepartmentId && x.IssueStatus == 0 && x.AdminDamageStatus == 0 && x.BorrowerDamageStatus == 0);
                var selectModels = traineeBioDataGeneralInfos.Select(x => new SelectedModel
                { 
                    Text = x.MergeId,
                    Value = x.BookInformationId
                }).ToList();
                return selectModels;
            }
      }
}
