using MediatR;
using SchoolManagement.Application.DTOs.BookTitleInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookTitleInfos.Requests.Commands
{
    public class UpdateBookTitleInfoCommand : IRequest<Unit>
    {
        public BookTitleInfoDto BookTitleInfoDto { get; set; }
    }
}
