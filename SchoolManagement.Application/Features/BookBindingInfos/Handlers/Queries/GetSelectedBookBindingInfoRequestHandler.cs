using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BookBindingInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookBindingInfos.Handlers.Queries
{
    public class GetSelectedBookBindingInfoRequestHandler : IRequestHandler<GetSelectedBookBindingInfoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BookBindingInfo> _BookBindingInfoRepository;


        public GetSelectedBookBindingInfoRequestHandler(ISchoolManagementRepository<BookBindingInfo> BookBindingInfoRepository)
        {
            _BookBindingInfoRepository = BookBindingInfoRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBookBindingInfoRequest request, CancellationToken cancellationToken)
        {
            ICollection<BookBindingInfo> codeValues = await _BookBindingInfoRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.PressName,
                Value = x.BookBindingInfoId
            }).ToList();
            return selectModels;
        }
    }
}
