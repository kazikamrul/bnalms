using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Designations.Requests.Commands
{
    public class DeleteDesignationCommand : IRequest
    {
        public int DesignationId { get; set; }
    }
}
