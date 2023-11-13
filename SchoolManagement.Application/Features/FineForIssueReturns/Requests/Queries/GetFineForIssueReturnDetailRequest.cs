using MediatR;
using SchoolManagement.Application.DTOs.FineForIssueReturns;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Requests.Queries
{
    public class GetFineForIssueReturnDetailRequest : IRequest<FineForIssueReturnDto>
    {
        public int FineForIssueReturnId { get; set; }
    }
}
