using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.DamageInformationByLibrary;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.DamageInformationByLibrarys.Requests.Queries
{
    public class GetDamageInformationByLibraryListRequest : IRequest<PagedResult<DamageInformationByLibraryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
