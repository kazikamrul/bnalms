using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Inventorys.Requests.Commands
{
    public class DeleteInventoryCommand : IRequest
    {
        public int InventoryId { get; set; }
    }
}
