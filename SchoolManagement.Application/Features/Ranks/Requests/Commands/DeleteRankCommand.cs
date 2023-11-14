using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Ranks.Requests.Commands
{
    public class DeleteRankCommand : IRequest
    {
        public int RankId { get; set; }
    }
}
