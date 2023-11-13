using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.LibraryAuthoritys.Requests.Queries
{
    public class GetSelectedLibraryAuthorityRequest : IRequest<List<SelectedModel>>
    {
    }
}
