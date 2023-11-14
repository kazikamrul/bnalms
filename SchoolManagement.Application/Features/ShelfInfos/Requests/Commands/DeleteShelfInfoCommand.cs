using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ShelfInfos.Requests.Commands
{
    public class DeleteShelfInfoCommand : IRequest
    {
        public int ShelfInfoId { get; set; }
    }
}
