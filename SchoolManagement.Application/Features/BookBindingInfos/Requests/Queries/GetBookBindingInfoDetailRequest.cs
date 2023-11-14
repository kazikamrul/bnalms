using MediatR;
using SchoolManagement.Application.DTOs.BookBindingInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookBindingInfos.Requests.Queries
{
    public class GetBookBindingInfoDetailRequest : IRequest<BookBindingInfoDto>
    {
        public int BookBindingInfoId { get; set; }
    }
}
