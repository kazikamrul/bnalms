using MediatR;
using SchoolManagement.Application.DTOs.Area;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Areas.Requests.Queries
{
    public class GetAreaDetailRequest : IRequest<AreaDto>
    {
        public int AreaId { get; set; }
    }
}
