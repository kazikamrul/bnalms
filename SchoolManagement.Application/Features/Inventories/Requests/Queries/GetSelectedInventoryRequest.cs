using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Inventorys.Requests.Queries
{
    public class GetSelectedInventoryRequest : IRequest<List<SelectedModel>>
    {
    }
}
