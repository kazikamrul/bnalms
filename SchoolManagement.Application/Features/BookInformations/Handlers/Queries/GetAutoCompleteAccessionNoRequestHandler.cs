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
    public class GetAutoCompleteAccessionNoRequestHandler : IRequestHandler<GetAutoCompleteAccessionNoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BookInformation> _BookInformationRepository; 
        public GetAutoCompleteAccessionNoRequestHandler(ISchoolManagementRepository<BookInformation> BookInformationRepository)
        {
            _BookInformationRepository = BookInformationRepository;
        }
          
        public async Task<List<SelectedModel>> Handle(GetAutoCompleteAccessionNoRequest request, CancellationToken cancellationToken)
        {
                ICollection<BookInformation> traineeBioDataGeneralInfos = await _BookInformationRepository.FilterAsync(x => x.IsActive && x.IssueStatus==0 && x.AccessionNo.Contains(request.accessionNo));
                var selectModels = traineeBioDataGeneralInfos.Select(x => new SelectedModel
                { 
                    Text = x.MergeId,
                    Value = x.BookInformationId
                }).ToList();
                return selectModels;
            }
      }
}
