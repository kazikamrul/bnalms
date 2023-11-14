using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.HelpLines.Requests.Queries
{
    public class GetSelectedHelpLineRequest : IRequest<List<SelectedModel>>
    {
    }
}
