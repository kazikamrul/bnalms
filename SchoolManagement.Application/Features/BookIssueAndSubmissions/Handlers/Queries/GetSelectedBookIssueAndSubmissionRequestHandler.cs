using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Handlers.Queries
{
    public class GetSelectedBookIssueAndSubmissionRequestHandler : IRequestHandler<GetSelectedBookIssueAndSubmissionRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BookIssueAndSubmission> _BookIssueAndSubmissionRepository;


        public GetSelectedBookIssueAndSubmissionRequestHandler(ISchoolManagementRepository<BookIssueAndSubmission> BookIssueAndSubmissionRepository)
        {
            _BookIssueAndSubmissionRepository = BookIssueAndSubmissionRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBookIssueAndSubmissionRequest request, CancellationToken cancellationToken)
        {
            ICollection<BookIssueAndSubmission> codeValues = await _BookIssueAndSubmissionRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.BookIssueAndSubmissionId,
                Value = x.BookIssueAndSubmissionId
            }).ToList();
            return selectModels;
        }
    }
}
