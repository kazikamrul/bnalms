using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SupplierInformations.Requests.Commands
{
    public class DeleteSupplierInformationCommand : IRequest
    {
        public int SupplierInformationId { get; set; }
    }
}
