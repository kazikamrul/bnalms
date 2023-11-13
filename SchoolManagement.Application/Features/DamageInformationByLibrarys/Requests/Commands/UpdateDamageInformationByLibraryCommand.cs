using MediatR;
using SchoolManagement.Application.DTOs.DamageInformationByLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DamageInformationByLibrarys.Requests.Commands
{
    public class UpdateDamageInformationByLibraryCommand : IRequest<Unit>
    {
        public DamageInformationByLibraryDto DamageInformationByLibraryDto { get; set; }
    }
}
