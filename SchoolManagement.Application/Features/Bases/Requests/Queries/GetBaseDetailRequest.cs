using MediatR;
using SchoolManagement.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Bases.Requests.Queries
{
    public class GetBaseDetailRequest : IRequest<BasemDto>
    {
        public int BaseId { get; set; }
    }
}
