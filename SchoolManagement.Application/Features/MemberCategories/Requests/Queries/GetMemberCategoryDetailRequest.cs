using MediatR;
using SchoolManagement.Application.DTOs.MemberCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MemberCategorys.Requests.Queries
{
    public class GetMemberCategoryDetailRequest : IRequest<MemberCategoryDto>
    {
        public int MemberCategoryId { get; set; }
    }
}
