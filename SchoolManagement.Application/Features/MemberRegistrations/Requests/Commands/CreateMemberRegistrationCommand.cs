using MediatR;
using SchoolManagement.Application.DTOs.MemberRegistration;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MemberRegistrations.Requests.Commands
{
    public class CreateMemberRegistrationCommand : IRequest<BaseCommandResponse>
    {
        public CreateMemberRegistrationDto MemberRegistrationDto { get; set; }
    }
}
