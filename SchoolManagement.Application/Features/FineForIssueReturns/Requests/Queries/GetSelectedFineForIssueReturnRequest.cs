using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Requests.Queries
{
    public class GetSelectedFineForIssueReturnRequest : IRequest<List<SelectedModel>>
    {
    }
}
