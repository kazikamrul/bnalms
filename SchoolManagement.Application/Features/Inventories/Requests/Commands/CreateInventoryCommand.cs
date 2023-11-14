using MediatR;
using SchoolManagement.Application.DTOs.Inventorys;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Inventorys.Requests.Commands
{
    public class CreateInventoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateInventoryDto InventoryDto { get; set; }
    }
}
