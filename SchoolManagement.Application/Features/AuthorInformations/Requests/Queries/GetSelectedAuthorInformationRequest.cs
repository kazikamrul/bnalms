using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.AuthorInformations.Requests.Queries
{
    public class GetSelectedAuthorInformationRequest : IRequest<List<SelectedModel>>
    {
    }
}
