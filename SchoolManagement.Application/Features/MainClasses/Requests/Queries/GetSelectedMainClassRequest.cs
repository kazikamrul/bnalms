using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.MainClasses.Requests.Queries
{
    public class GetSelectedMainClassRequest : IRequest<List<SelectedModel>>
    {
    }
}
