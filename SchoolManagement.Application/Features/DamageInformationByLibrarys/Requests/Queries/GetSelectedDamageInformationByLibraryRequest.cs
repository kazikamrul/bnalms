using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.DamageInformationByLibrarys.Requests.Queries
{
    public class GetSelectedDamageInformationByLibraryRequest : IRequest<List<SelectedModel>>
    {
    }
}
