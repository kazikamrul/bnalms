using MediatR;
using SchoolManagement.Application.DTOs.Rank;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Ranks.Requests.Commands
{
    public class UpdateRankCommand : IRequest<Unit>
    {
        public RankDto RankDto { get; set; }
    }
}
