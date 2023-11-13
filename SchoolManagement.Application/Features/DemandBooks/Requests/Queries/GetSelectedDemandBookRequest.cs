using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.DemandBooks.Requests.Queries
{
    public class GetSelectedDemandBookRequest : IRequest<List<SelectedModel>>
    {
    }
}
