using MediatR;
using SchoolManagement.Application.DTOs.BookIssueAndSubmission;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries
{
    public class GetBookIssueAndSubmissionDetailRequest : IRequest<BookIssueAndSubmissionDto>
    {
        public int BookIssueAndSubmissionId { get; set; }
    }
}
