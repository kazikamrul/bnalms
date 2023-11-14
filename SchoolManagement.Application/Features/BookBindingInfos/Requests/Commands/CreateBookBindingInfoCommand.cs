using MediatR;
using SchoolManagement.Application.DTOs.BookBindingInfo;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookBindingInfos.Requests.Commands
{
    public class CreateBookBindingInfoCommand : IRequest<BaseCommandResponse>
    {
        public CreateBookBindingInfoDto BookBindingInfoDto { get; set; }
    }
}
