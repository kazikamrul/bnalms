using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.ShelfInfos.Requests.Queries
{
    public class GetSelectedShelfInfoRequest : IRequest<List<SelectedModel>>
    {
    }
}
