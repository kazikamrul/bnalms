using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.SupplierInformations.Requests.Queries
{
    public class GetSelectedSupplierInformationRequest : IRequest<List<SelectedModel>>
    {
    }
}
