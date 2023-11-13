using MediatR;
using SchoolManagement.Application.DTOs.InventoryTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InventoryTypes.Requests.Queries
{
    public class GetInventoryTypeDetailRequest : IRequest<InventoryTypeDto>
    {
        public int InventoryTypeId { get; set; }
    }
}
