using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.InformationFezups.Requests.Queries
{
    public class GetSelectedInformationFezupRequest : IRequest<List<SelectedModel>>
    {
    }
}
