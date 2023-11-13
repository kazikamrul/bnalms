using MediatR;
using SchoolManagement.Application.DTOs.Inventorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Inventorys.Requests.Queries
{
    public class GetInventoryDetailRequest : IRequest<InventoryDto>
    {
        public int InventoryId { get; set; }
    }
}
