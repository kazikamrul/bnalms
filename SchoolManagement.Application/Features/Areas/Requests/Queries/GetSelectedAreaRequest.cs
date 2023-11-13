using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Areas.Requests.Queries
{
    public class GetSelectedAreaRequest : IRequest<List<SelectedModel>>
    {
    }
}
