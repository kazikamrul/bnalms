using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.FineForIssueReturns.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Handlers.Queries
{
    public class GetSelectedFineForIssueReturnRequestHandler : IRequestHandler<GetSelectedFineForIssueReturnRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<FineForIssueReturn> _FineForIssueReturnRepository;


        public GetSelectedFineForIssueReturnRequestHandler(ISchoolManagementRepository<FineForIssueReturn> FineForIssueReturnRepository)
        {
            _FineForIssueReturnRepository = FineForIssueReturnRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedFineForIssueReturnRequest request, CancellationToken cancellationToken)
        {
            ICollection<FineForIssueReturn> codeValues = await _FineForIssueReturnRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Amount,
                Value = x.FineForIssueReturnId
            }).ToList();
            return selectModels;
        }
    }
}
