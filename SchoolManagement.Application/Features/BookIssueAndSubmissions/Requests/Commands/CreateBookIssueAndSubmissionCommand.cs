using MediatR;
using SchoolManagement.Application.DTOs.BookIssueAndSubmission;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Commands
{
    public class CreateBookIssueAndSubmissionCommand : IRequest<BaseCommandResponse>
    {
        public CreateBookIssueAndSubmissionDto BookIssueAndSubmissionDto { get; set; }
    }
}
