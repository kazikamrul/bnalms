using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.NoticeInfos.Requests.Queries
{
    public class GetSelectedNoticeInfoRequest : IRequest<List<SelectedModel>>
    {
    }
}
