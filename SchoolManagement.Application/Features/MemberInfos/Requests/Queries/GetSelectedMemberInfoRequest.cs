﻿using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.MemberInfos.Requests.Queries
{
    public class GetSelectedMemberInfoRequest : IRequest<List<SelectedModel>>
    {
    }
}
