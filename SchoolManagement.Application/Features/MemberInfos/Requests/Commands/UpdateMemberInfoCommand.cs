using MediatR;
using SchoolManagement.Application.DTOs.MemberInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MemberInfos.Requests.Commands
{
    public class UpdateMemberInfoCommand : IRequest<Unit>
    {
        public CreateMemberInfoDto CreateMemberInfoDto { get; set; }
    }
}
