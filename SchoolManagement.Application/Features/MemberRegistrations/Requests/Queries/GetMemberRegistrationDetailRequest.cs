using MediatR;
using SchoolManagement.Application.DTOs.MemberRegistration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MemberRegistrations.Requests.Queries
{
    public class GetMemberRegistrationDetailRequest : IRequest<MemberRegistrationDto>
    {
        public int MemberRegistrationId { get; set; }
    }
}
