using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Areas.Requests.Commands
{
    public class DeleteAreaCommand : IRequest
    {
        public int AreaId { get; set; }
    }
}
