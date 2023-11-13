using MediatR;
using SchoolManagement.Application.DTOs.Rank;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Ranks.Requests.Commands
{
    public class CreateRankCommand : IRequest<BaseCommandResponse>
    {
        public CreateRankDto RankDto { get; set; }
    }
}
