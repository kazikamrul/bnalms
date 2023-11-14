using MediatR;
using SchoolManagement.Application.DTOs.DamageInformationByLibrary;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DamageInformationByLibrarys.Requests.Commands
{
    public class CreateDamageInformationByLibraryCommand : IRequest<BaseCommandResponse>
    {
        public CreateDamageInformationByLibraryDto DamageInformationByLibraryDto { get; set; }
    }
}
