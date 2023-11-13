using MediatR;
using SchoolManagement.Application.DTOs.AuthorInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.AuthorInformations.Requests.Queries
{
    public class GetAuthorInformationDetailRequest : IRequest<AuthorInformationDto>
    {
        public int AuthorInformationId { get; set; }
    }
}
