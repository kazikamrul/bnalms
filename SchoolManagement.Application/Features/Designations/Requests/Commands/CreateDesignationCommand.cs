using MediatR;
using SchoolManagement.Application.DTOs.Designation;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Designations.Requests.Commands
{
    public class CreateDesignationCommand : IRequest<BaseCommandResponse>
    {
        public CreateDesignationDto DesignationDto { get; set; }
    }
}
