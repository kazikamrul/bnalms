using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookTitleInfos.Requests.Commands
{
    public class DeleteBookTitleInfoCommand : IRequest
    {
        public int BookTitleInfoId { get; set; }
    }
}
