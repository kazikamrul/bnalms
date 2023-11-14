using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BookTitleInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookTitleInfos.Handlers.Queries
{
    public class GetAutoCompleteBookTitleRequestHandler : IRequestHandler<GetAutoCompleteBookTitleRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BookTitleInfo> _BookTitleInfoRepository; 
        public GetAutoCompleteBookTitleRequestHandler(ISchoolManagementRepository<BookTitleInfo> BookTitleInfoRepository)
        {
            _BookTitleInfoRepository = BookTitleInfoRepository;
        }
          
        public async Task<List<SelectedModel>> Handle(GetAutoCompleteBookTitleRequest request, CancellationToken cancellationToken)
        {
                ICollection<BookTitleInfo> traineeBioDataGeneralInfos = await _BookTitleInfoRepository.FilterAsync(x => x.BookTitleName.Contains(request.Title));
                var selectModels = traineeBioDataGeneralInfos.Select(x => new SelectedModel
                { 
                    Text = x.BookTitleName+'-'+x.TitleBangla,
                    Value = x.BookTitleInfoId
                }).ToList();
                return selectModels;
            }
      }
}
