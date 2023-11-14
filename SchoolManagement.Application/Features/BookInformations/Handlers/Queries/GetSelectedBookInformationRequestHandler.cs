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
    public class GetSelectedBookInformationRequestHandler : IRequestHandler<GetSelectedBookInformationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BookInformation> _BookInformationRepository;


        public GetSelectedBookInformationRequestHandler(ISchoolManagementRepository<BookInformation> BookInformationRepository)
        {
            _BookInformationRepository = BookInformationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBookInformationRequest request, CancellationToken cancellationToken)
        {
            ICollection<BookInformation> codeValues = await _BookInformationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.BookTitleInfo.BookTitleName+'-'+x.BookTitleInfo.TitleBangla,
                Value = x.BookInformationId
            }).ToList();
            return selectModels;
        }
    }
}
