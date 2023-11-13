using MediatR;
using SchoolManagement.Application.DTOs.BookTitleInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookTitleInfos.Requests.Queries
{
    public class GetBookTitleInfoDetailRequest : IRequest<BookTitleInfoDto>
    {
        public int BookTitleInfoId { get; set; }
    }
}
