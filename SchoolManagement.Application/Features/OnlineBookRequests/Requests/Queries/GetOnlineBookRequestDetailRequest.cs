using MediatR;
using SchoolManagement.Application.DTOs.OnlineBookRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Requests.Queries
{
    public class GetOnlineBookRequestDetailRequest : IRequest<OnlineBookRequestDto>
    {
        public int OnlineBookRequestId { get; set; }
    }
}
