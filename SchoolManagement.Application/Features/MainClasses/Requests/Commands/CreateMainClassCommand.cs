using MediatR;
using SchoolManagement.Application.DTOs.MainClass;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MainClasses.Requests.Commands
{
    public class CreateMainClassCommand : IRequest<BaseCommandResponse>
    {
        public CreateMainClassDto MainClassDto { get; set; }
    }
}
