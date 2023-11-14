using MediatR;
using SchoolManagement.Application.DTOs.RowInfo;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.RowInfos.Requests.Commands
{
    public class CreateRowInfoCommand : IRequest<BaseCommandResponse>
    {
        public CreateRowInfoDto RowInfoDto { get; set; }
    }
}
