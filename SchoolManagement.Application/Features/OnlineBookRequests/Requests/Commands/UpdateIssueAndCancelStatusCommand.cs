using MediatR;
using SchoolManagement.Application.DTOs.OnlineBookRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Requests.Commands
{
    public class UpdateIssueAndCancelStatusCommand : IRequest<Unit>
    {
        public int OnlineBookRequestId { get; set; }
        public int BookInformationId { get; set; }
    }
} 
  