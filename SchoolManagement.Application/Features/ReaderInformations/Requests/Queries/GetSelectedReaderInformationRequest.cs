using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.ReaderInformations.Requests.Queries
{
    public class GetSelectedReaderInformationRequest : IRequest<List<SelectedModel>>
    {
    }
}
