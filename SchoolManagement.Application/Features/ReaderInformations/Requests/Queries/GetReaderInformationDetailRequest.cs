using MediatR;
using SchoolManagement.Application.DTOs.ReaderInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ReaderInformations.Requests.Queries
{
    public class GetReaderInformationDetailRequest : IRequest<ReaderInformationDto>
    {
        public int ReaderInformationId { get; set; }
    }
}
