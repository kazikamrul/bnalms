using MediatR;
using SchoolManagement.Application.DTOs.FeeCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FeeCategorys.Requests.Commands
{
    public class UpdateFeeCategoryCommand : IRequest<Unit>
    {
        public FeeCategoryDto FeeCategoryDto { get; set; }
    }
}
