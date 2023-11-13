using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.RowInfos.Requests.Commands
{
    public class DeleteRowInfoCommand : IRequest
    {
        public int RowInfoId { get; set; }
    }
}
