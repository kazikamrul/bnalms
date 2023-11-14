using MediatR;
using SchoolManagement.Application.DTOs.Base;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Bases.Requests.Commands
{
    public class CreateBaseCommand : IRequest<BaseCommandResponse>
    {
        public CreateBasemDto BasemDto { get; set; }
    }
}
