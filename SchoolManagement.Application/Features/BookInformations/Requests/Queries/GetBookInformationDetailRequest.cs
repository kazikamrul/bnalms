using MediatR;
using SchoolManagement.Application.DTOs.BookInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetBookInformationDetailRequest : IRequest<BookInformationDto>
    {
        public int BookInformationId { get; set; }
    }
}
