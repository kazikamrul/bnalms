using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MainClasses.Requests.Commands
{
    public class DeleteMainClassCommand : IRequest
    {
        public int MainClassId { get; set; }
    }
}
