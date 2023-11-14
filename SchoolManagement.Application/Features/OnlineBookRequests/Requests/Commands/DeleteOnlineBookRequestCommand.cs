using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Requests.Commands
{
    public class DeleteOnlineBookRequestCommand : IRequest
    {
        public int OnlineBookRequestId { get; set; }
    }
}
