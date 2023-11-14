using MediatR;
using SchoolManagement.Application.DTOs.RowInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.RowInfos.Requests.Queries
{
    public class GetRowInfoDetailRequest : IRequest<RowInfoDto>
    {
        public int RowInfoId { get; set; }
    }
}
