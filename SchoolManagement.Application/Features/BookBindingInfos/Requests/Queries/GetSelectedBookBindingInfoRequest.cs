using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BookBindingInfos.Requests.Queries
{
    public class GetSelectedBookBindingInfoRequest : IRequest<List<SelectedModel>>
    {
    }
}
