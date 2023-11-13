using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.MemberCategorys.Requests.Queries
{
    public class GetSelectedMemberCategoryRequest : IRequest<List<SelectedModel>>
    {
    }
}
