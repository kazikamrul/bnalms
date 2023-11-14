using MediatR;
using SchoolManagement.Application.DTOs.FeeInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FeeInformations.Requests.Queries
{
    public class GetFeeInformationDetailRequest : IRequest<FeeInformationDto>
    {
        public int FeeInformationId { get; set; }
    }
}
