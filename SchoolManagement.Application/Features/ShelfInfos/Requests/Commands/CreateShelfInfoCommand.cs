using MediatR;
using SchoolManagement.Application.DTOs.ShelfInfo;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ShelfInfos.Requests.Commands
{
    public class CreateShelfInfoCommand : IRequest<BaseCommandResponse>
    {
        public CreateShelfInfoDto ShelfInfoDto { get; set; }
    }
}
