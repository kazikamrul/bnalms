using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries
{
    public class GetSelectedBookIssueAndSubmissionRequest : IRequest<List<SelectedModel>>
    {
    }
}
