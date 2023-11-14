using MediatR;
using SchoolManagement.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Bases.Requests.Commands
{
    public class UpdateBaseCommand : IRequest<Unit>
    {
        public BasemDto BasemDto { get; set; }
    }
}
