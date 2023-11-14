using MediatR;
using SchoolManagement.Application.DTOs.Source;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Sources.Requests.Queries
{
    public class GetSourceDetailRequest : IRequest<SourceDto>
    {
        public int SourceId { get; set; }
    }
}
