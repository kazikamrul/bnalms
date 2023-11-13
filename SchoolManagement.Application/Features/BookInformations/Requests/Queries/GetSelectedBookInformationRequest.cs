using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetSelectedBookInformationRequest : IRequest<List<SelectedModel>>
    {
    }
}
