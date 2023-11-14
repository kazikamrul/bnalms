using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Designations.Requests.Queries
{
    public class GetSelectedDesignationRequest : IRequest<List<SelectedModel>>
    {
    }
}
