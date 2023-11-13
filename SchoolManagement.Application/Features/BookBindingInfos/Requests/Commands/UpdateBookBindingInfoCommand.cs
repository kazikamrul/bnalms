using MediatR;
using SchoolManagement.Application.DTOs.BookBindingInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookBindingInfos.Requests.Commands
{
    public class UpdateBookBindingInfoCommand : IRequest<Unit>
    {
        public BookBindingInfoDto BookBindingInfoDto { get; set; }
    }
}
