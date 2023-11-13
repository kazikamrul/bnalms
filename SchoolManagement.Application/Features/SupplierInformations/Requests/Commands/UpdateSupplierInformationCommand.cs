using MediatR;
using SchoolManagement.Application.DTOs.SupplierInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SupplierInformations.Requests.Commands
{
    public class UpdateSupplierInformationCommand : IRequest<Unit>
    {
        public SupplierInformationDto SupplierInformationDto { get; set; }
    }
}
