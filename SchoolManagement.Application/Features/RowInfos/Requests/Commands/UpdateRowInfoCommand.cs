using MediatR;
using SchoolManagement.Application.DTOs.RowInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.RowInfos.Requests.Commands
{
    public class UpdateRowInfoCommand : IRequest<Unit>
    {
        public RowInfoDto RowInfoDto { get; set; }
    }
}
