using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DamageInformationByLibrarys.Requests.Commands
{
    public class DeleteDamageInformationByLibraryCommand : IRequest
    {
        public int DamageInformationByLibraryId { get; set; }
    }
}
