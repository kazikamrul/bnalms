using MediatR;
using SchoolManagement.Application.DTOs.Language;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Languages.Requests.Queries
{
    public class GetLanguageDetailRequest : IRequest<LanguageDto>
    {
        public int LanguageId { get; set; }
    }
}
