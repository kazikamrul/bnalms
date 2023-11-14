using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MemberInfos.Requests.Commands
{
    public class DeleteMemberInfoCommand : IRequest
    {
        public int MemberInfoId { get; set; }
    }
}
