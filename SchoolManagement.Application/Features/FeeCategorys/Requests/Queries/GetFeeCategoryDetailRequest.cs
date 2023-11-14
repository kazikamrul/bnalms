using MediatR;
using SchoolManagement.Application.DTOs.FeeCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FeeCategorys.Requests.Queries
{
    public class GetFeeCategoryDetailRequest : IRequest<FeeCategoryDto>
    {
        public int FeeCategoryId { get; set; }
    }
}
