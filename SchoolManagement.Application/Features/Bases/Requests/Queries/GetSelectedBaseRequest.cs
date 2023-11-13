using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Bases.Requests.Queries
{
    public class GetSelectedBaseRequest : IRequest<List<SelectedModel>>
    {
    }
}
