using MediatR;
using SchoolManagement.Application.DTOs.InformationFezup;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InformationFezups.Requests.Queries
{
    public class GetInformationFezupDetailRequest : IRequest<InformationFezupDto>
    {
        public int InformationFezupId { get; set; }
    }
}
