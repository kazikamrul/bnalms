using MediatR;
using SchoolManagement.Application.DTOs.ShelfInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ShelfInfos.Requests.Commands
{
    public class UpdateShelfInfoCommand : IRequest<Unit>
    {
        public ShelfInfoDto ShelfInfoDto { get; set; }
    }
}
