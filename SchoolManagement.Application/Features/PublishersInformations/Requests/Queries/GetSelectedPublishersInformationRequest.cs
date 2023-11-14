using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.PublishersInformations.Requests.Queries
{
    public class GetSelectedPublishersInformationRequest : IRequest<List<SelectedModel>>
    {
    }
}
