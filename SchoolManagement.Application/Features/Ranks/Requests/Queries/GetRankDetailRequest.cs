using MediatR;
using SchoolManagement.Application.DTOs.Rank;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Ranks.Requests.Queries
{
    public class GetRankDetailRequest : IRequest<RankDto>
    {
        public int RankId { get; set; }
    }
}
