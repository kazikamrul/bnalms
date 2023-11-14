using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.SourceInformations.Requests.Queries
{
    public class GetSelectedSourceInformationRequest : IRequest<List<SelectedModel>>
    {
    }
}
