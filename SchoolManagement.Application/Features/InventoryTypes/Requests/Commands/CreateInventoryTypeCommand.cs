using MediatR;
using SchoolManagement.Application.DTOs.InventoryTypes;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InventoryTypes.Requests.Commands
{
    public class CreateInventoryTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateInventoryTypeDto InventoryTypeDto { get; set; }
    }
}
