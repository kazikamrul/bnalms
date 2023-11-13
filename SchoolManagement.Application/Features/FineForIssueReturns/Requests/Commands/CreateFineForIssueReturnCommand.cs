using MediatR;
using SchoolManagement.Application.DTOs.FineForIssueReturns;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Requests.Commands
{
    public class CreateFineForIssueReturnCommand : IRequest<BaseCommandResponse>
    {
        public CreateFineForIssueReturnDto FineForIssueReturnDto { get; set; }
    }
}
