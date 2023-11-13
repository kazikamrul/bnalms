using MediatR;
using SchoolManagement.Application.DTOs.MemberInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MemberInfos.Requests.Queries
{
    public class GetMemberInfoDetailRequest : IRequest<MemberInfoDto>
    {
        public int MemberInfoId { get; set; }
    }
}
