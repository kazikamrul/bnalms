using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.MemberRegistrations.Requests.Queries
{
    public class GetSelectedMemberRegistrationRequest : IRequest<List<SelectedModel>>
    {
    }
}
