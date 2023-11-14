using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Queries
{
    public class GetSelectedBulletinRequest : IRequest<List<SelectedModel>>
    {
    }
}
