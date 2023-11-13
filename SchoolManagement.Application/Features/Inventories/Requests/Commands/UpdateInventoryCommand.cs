using MediatR;
using SchoolManagement.Application.DTOs.Inventorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Inventorys.Requests.Commands
{
    public class UpdateInventoryCommand : IRequest<Unit>
    {
        public InventoryDto InventoryDto { get; set; }
    }
}
