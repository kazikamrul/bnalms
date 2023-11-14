using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MemberCategorys.Requests.Commands
{
    public class DeleteMemberCategoryCommand : IRequest
    {
        public int MemberCategoryId { get; set; }
    }
}
