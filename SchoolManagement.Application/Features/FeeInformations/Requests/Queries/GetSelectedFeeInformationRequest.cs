using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.FeeInformations.Requests.Queries
{
    public class GetSelectedFeeInformationRequest : IRequest<List<SelectedModel>>
    {
    }
}
