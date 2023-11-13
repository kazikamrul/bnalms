using MediatR;
using SchoolManagement.Application.DTOs.Area;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Areas.Requests.Commands
{
    public class CreateAreaCommand : IRequest<BaseCommandResponse>
    {
        public CreateAreaDto AreaDto { get; set; }
    }
}
