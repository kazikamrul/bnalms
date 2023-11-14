using MediatR;
using SchoolManagement.Application.DTOs.InformationFezup;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InformationFezups.Requests.Commands
{
    public class CreateInformationFezupCommand : IRequest<BaseCommandResponse>
    {
        public CreateInformationFezupDto InformationFezupDto { get; set; }
    }
}
