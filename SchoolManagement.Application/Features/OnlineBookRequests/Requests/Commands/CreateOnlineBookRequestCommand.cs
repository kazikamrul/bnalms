using MediatR;
using SchoolManagement.Application.DTOs.OnlineBookRequest;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Requests.Commands
{
    public class CreateOnlineBookRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateOnlineBookRequestDto OnlineBookRequestDto { get; set; }
    }
}
