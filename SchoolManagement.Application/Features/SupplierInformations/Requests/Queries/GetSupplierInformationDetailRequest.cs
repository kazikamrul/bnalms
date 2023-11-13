using MediatR;
using SchoolManagement.Application.DTOs.SupplierInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SupplierInformations.Requests.Queries
{
    public class GetSupplierInformationDetailRequest : IRequest<SupplierInformationDto>
    {
        public int SupplierInformationId { get; set; }
    }
}
