using MediatR;
using SchoolManagement.Application.DTOs.SupplierInformation;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SupplierInformations.Requests.Commands
{
    public class CreateSupplierInformationCommand : IRequest<BaseCommandResponse>
    {
        public CreateSupplierInformationDto SupplierInformationDto { get; set; }
    }
}
