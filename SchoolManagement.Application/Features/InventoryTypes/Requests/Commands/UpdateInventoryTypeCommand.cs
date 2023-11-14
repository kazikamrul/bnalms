using MediatR;
using SchoolManagement.Application.DTOs.InventoryTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InventoryTypes.Requests.Commands
{
    public class UpdateInventoryTypeCommand : IRequest<Unit>
    {
        public InventoryTypeDto InventoryTypeDto { get; set; }
    }
}
