using MediatR;
using SchoolManagement.Application.DTOs.OnlineBookRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Requests.Commands
{
    public class UpdateOnlineBookRequestCommand : IRequest<Unit>
    {
        public OnlineBookRequestDto OnlineBookRequestDto { get; set; }
    }
}
