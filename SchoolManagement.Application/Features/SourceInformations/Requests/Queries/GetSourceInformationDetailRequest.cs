using MediatR;
using SchoolManagement.Application.DTOs.SourceInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SourceInformations.Requests.Queries
{
    public class GetSourceInformationDetailRequest : IRequest<SourceInformationDto>
    {
        public int SourceInformationId { get; set; }
    }
}
