using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InformationFezups.Requests.Commands
{
    public class DeleteInformationFezupCommand : IRequest
    {
        public int InformationFezupId { get; set; }
    }
}
