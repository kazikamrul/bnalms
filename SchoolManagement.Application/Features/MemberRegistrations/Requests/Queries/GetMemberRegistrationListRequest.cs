using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.MemberRegistration;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MemberRegistrations.Requests.Queries
{
    public class GetMemberRegistrationListRequest : IRequest<PagedResult<MemberRegistrationDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
