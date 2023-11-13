using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Commands
{
    public class DeleteBookIssueAndSubmissionCommand : IRequest
    {
        public int BookIssueAndSubmissionId { get; set; }
    }
}
