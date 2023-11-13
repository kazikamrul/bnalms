using MediatR;
using SchoolManagement.Application.DTOs.Designation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Designations.Requests.Queries
{
    public class GetDesignationDetailRequest : IRequest<DesignationDto>
    {
        public int DesignationId { get; set; }
    }
}
