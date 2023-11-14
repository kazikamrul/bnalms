using MediatR;
using SchoolManagement.Application.DTOs.MemberRegistration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MemberRegistrations.Requests.Commands
{
    public class UpdateMemberRegistrationCommand : IRequest<Unit>
    {
        public MemberRegistrationDto MemberRegistrationDto { get; set; }
    }
}
