using MediatR;
using SchoolManagement.Application.DTOs.BookIssueAndSubmission;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Commands
{
    public class UpdateBookIssueAndSubmissionCommand : IRequest<Unit>
    {
        public BookIssueAndSubmissionDto BookIssueAndSubmissionDto { get; set; }
    }
}
