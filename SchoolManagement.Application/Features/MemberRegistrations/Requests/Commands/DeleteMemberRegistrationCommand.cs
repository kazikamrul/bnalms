using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MemberRegistrations.Requests.Commands
{
    public class DeleteMemberRegistrationCommand : IRequest
    {
        public int MemberRegistrationId { get; set; }
    }
}
