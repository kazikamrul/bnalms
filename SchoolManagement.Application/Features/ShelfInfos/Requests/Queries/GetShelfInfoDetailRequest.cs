using MediatR;
using SchoolManagement.Application.DTOs.ShelfInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ShelfInfos.Requests.Queries
{
    public class GetShelfInfoDetailRequest : IRequest<ShelfInfoDto>
    {
        public int ShelfInfoId { get; set; }
    }
}
