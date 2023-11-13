using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Requests.Commands
{
    public class DeleteFineForIssueReturnCommand : IRequest
    {
        public int FineForIssueReturnId { get; set; }
    }
}
