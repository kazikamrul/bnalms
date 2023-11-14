using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.AuthorityCategorys.Requests.Queries
{
    public class GetSelectedAuthorityCategoryRequest : IRequest<List<SelectedModel>>
    {
    }
}
