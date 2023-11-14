using MediatR;
using SchoolManagement.Application.DTOs.MemberCategory;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MemberCategorys.Requests.Commands
{
    public class CreateMemberCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateMemberCategoryDto MemberCategoryDto { get; set; }
    }
}
 