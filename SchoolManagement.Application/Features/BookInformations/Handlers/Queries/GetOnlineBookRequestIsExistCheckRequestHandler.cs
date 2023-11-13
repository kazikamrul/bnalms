using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookInformations.Handlers.Queries
{
    public class GetOnlineBookRequestIsExistCheckRequestHandler : IRequestHandler<GetOnlineBookRequestIsExistCheckRequest, bool>
    {
        private readonly ISchoolManagementRepository<OnlineBookRequest> _OnlineBookRequestRepository; 
        public GetOnlineBookRequestIsExistCheckRequestHandler(ISchoolManagementRepository<OnlineBookRequest> OnlineBookRequestRepository)
        {
            _OnlineBookRequestRepository = OnlineBookRequestRepository;
        }
          
        public async Task<bool> Handle(GetOnlineBookRequestIsExistCheckRequest request, CancellationToken cancellationToken)
        {
            ICollection<OnlineBookRequest> bookList = await _OnlineBookRequestRepository.FilterAsync(x => x.IsActive);
            var onlineRequests = bookList.Where(x => x.MemberInfoId == request.Pno && x.BookInformationId == request.BookInformationId && x.RequestStatus ==0 && x.CancelStatus == 0).ToList();
            if (onlineRequests.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }
      }
}
