using MediatR;
using SchoolManagement.Application.DTOs.MemberCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MemberCategorys.Requests.Commands
{
    public class UpdateMemberCategoryCommand : IRequest<Unit>
    {
        public MemberCategoryDto MemberCategoryDto { get; set; }
    }
}
