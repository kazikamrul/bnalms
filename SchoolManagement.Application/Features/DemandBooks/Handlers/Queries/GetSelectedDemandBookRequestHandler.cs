using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DemandBooks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DemandBooks.Handlers.Queries
{
    public class GetSelectedDemandBookRequestHandler : IRequestHandler<GetSelectedDemandBookRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DemandBook> _DemandBookRepository;


        public GetSelectedDemandBookRequestHandler(ISchoolManagementRepository<DemandBook> DemandBookRepository)
        {
            _DemandBookRepository = DemandBookRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDemandBookRequest request, CancellationToken cancellationToken)
        {
            ICollection<DemandBook> codeValues = await _DemandBookRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.BookName,
                Value = x.DemandBookId
            }).ToList();
            return selectModels;
        }
    }
}
