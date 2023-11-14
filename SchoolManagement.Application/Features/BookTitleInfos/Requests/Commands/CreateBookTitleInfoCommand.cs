using MediatR;
using SchoolManagement.Application.DTOs.BookTitleInfo;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookTitleInfos.Requests.Commands
{
    public class CreateBookTitleInfoCommand : IRequest<BaseCommandResponse>
    {
        public CreateBookTitleInfoDto BookTitleInfoDto { get; set; }
    }
}
