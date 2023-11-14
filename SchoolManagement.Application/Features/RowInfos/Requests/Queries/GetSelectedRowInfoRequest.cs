using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.RowInfos.Requests.Queries
{
    public class GetSelectedRowInfoRequest : IRequest<List<SelectedModel>>
    {
    }
}
