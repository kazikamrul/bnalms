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
    public class GetSelectedBookTitleInfoRequestHandler : IRequestHandler<GetSelectedBookTitleInfoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BookTitleInfo> _BookTitleInfoRepository;


        public GetSelectedBookTitleInfoRequestHandler(ISchoolManagementRepository<BookTitleInfo> BookTitleInfoRepository)
        {
            _BookTitleInfoRepository = BookTitleInfoRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBookTitleInfoRequest request, CancellationToken cancellationToken)
        {
            ICollection<BookTitleInfo> codeValues = await _BookTitleInfoRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.BookTitleName,
                Value = x.BookTitleInfoId
            }).ToList();
            return selectModels;
        }
    }
}
