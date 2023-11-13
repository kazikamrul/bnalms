using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InventoryTypes.Requests.Commands
{
    public class DeleteInventoryTypeCommand : IRequest
    {
        public int InventoryTypeId { get; set; }
    }
}
