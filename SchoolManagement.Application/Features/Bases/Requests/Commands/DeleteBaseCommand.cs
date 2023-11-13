using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Bases.Requests.Commands
{
    public class DeleteBaseCommand : IRequest
    {
        public int BaseId { get; set; }
    }
}
