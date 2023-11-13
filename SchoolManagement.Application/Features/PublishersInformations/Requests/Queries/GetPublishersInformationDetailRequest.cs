using MediatR;
using SchoolManagement.Application.DTOs.PublishersInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.PublishersInformations.Requests.Queries
{
    public class GetPublishersInformationDetailRequest : IRequest<PublishersInformationDto>
    {
        public int PublishersInformationId { get; set; }
    }
}
