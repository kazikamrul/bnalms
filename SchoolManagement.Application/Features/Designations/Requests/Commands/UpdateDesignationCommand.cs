using MediatR;
using SchoolManagement.Application.DTOs.Designation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Designations.Requests.Commands
{
    public class UpdateDesignationCommand : IRequest<Unit>
    {
        public DesignationDto DesignationDto { get; set; }
    }
}
