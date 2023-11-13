using MediatR;
using SchoolManagement.Application.DTOs.Area;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Areas.Requests.Commands
{
    public class UpdateAreaCommand : IRequest<Unit>
    {
        public AreaDto AreaDto { get; set; }
    }
}
