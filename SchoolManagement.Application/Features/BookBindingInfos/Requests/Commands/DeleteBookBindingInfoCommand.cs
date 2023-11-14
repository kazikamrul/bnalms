using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookBindingInfos.Requests.Commands
{
    public class DeleteBookBindingInfoCommand : IRequest
    {
        public int BookBindingInfoId { get; set; }
    }
}
