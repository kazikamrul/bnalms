using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.OnlineBookRequests.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Handlers.Queries
{
    public class GetOnlineRequestIsExistCheckRequestHandler : IRequestHandler<GetOnlineRequestIsExistCheckRequest, bool>
    {
        private readonly ISchoolManagementRepository<OnlineBookRequest> _OnlineBookRequestRepository; 
        public GetOnlineRequestIsExistCheckRequestHandler(ISchoolManagementRepository<OnlineBookRequest> OnlineBookRequestRepository)
        {
            _OnlineBookRequestRepository = OnlineBookRequestRepository;
        }
          
        public async Task<bool> Handle(GetOnlineRequestIsExistCheckRequest request, CancellationToken cancellationToken)
        {
            ICollection<OnlineBookRequest> bookList = await _OnlineBookRequestRepository.FilterAsync(x => x.IsActive);
            //var selectModels = traineeBioDataGeneralInfos.Select(x => new SelectedModel
            //{
            //    Text = x.AccessionNo,
            //    Value = x.OnlineBookRequestId
            //}).ToList(); 
            //return selectModels;
            bool isExist = bookList.Any(x => x.BookInformationId == request.BookInformationId && x.MemberInfoId == request.MemberInfoId);
            //if (isExist)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return isExist;
        }
      }
}
