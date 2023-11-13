using MediatR;
using SchoolManagement.Application.DTOs.InformationFezup;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InformationFezups.Requests.Commands
{
    public class UpdateInformationFezupCommand : IRequest<Unit>
    {
        public InformationFezupDto InformationFezupDto { get; set; }
    }
}
