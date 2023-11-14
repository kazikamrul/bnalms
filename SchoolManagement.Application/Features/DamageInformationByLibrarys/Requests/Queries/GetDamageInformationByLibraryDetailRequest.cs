using MediatR;
using SchoolManagement.Application.DTOs.DamageInformationByLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DamageInformationByLibrarys.Requests.Queries
{
    public class GetDamageInformationByLibraryDetailRequest : IRequest<DamageInformationByLibraryDto>
    {
        public int DamageInformationByLibraryId { get; set; }
    }
}
