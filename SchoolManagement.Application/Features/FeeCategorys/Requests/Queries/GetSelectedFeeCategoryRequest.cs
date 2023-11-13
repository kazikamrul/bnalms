using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.FeeCategorys.Requests.Queries
{
    public class GetSelectedFeeCategoryRequest : IRequest<List<SelectedModel>>
    {
    }
}
