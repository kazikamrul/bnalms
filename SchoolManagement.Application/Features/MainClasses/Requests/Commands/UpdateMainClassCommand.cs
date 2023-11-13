using MediatR;
using SchoolManagement.Application.DTOs.MainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MainClasses.Requests.Commands
{
    public class UpdateMainClassCommand : IRequest<Unit>
    {
        public MainClassDto MainClassDto { get; set; }
    }
}
