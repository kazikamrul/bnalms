using MediatR;
using SchoolManagement.Application.DTOs.FineForIssueReturns;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Requests.Commands
{
    public class UpdateFineForIssueReturnCommand : IRequest<Unit>
    {
        public FineForIssueReturnDto FineForIssueReturnDto { get; set; }
    }
}
