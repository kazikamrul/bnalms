using MediatR;
using SchoolManagement.Application.DTOs.FeeCategory;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FeeCategorys.Requests.Commands
{
    public class CreateFeeCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateFeeCategoryDto FeeCategoryDto { get; set; }
    }
}
