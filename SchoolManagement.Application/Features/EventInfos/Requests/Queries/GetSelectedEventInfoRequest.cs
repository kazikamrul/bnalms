using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.EventInfos.Requests.Queries
{
    public class GetSelectedEventInfoRequest : IRequest<List<SelectedModel>>
    {
    }
}
