using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.NoticeTypes.Requests.Queries
{
    public class GetSelectedNoticeTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
