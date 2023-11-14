using MediatR;
using SchoolManagement.Application.DTOs.HelpLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.HelpLines.Requests.Queries
{
    public class GetHelpLineDetailRequest : IRequest<HelpLineDto>
    {
        public int HelpLineId { get; set; }
    }
}
