using MediatR;
using SchoolManagement.Application.DTOs.MemberInfo;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MemberInfos.Requests.Commands
{
    public class CreateMemberInfoCommand : IRequest<BaseCommandResponse>
    {
        public CreateMemberInfoDto MemberInfoDto { get; set; }
    }
}
