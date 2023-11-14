using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OnlineBookRequests.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Handlers.Queries
{
    public class UserOnlineBookRequestHandler : IRequestHandler<UserOnlineBookRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<OnlineBookRequest> _OnlineBookRequestRepository;

        public UserOnlineBookRequestHandler(IUnitOfWork unitOfWork,
            IMapper mapper, 
            ISchoolManagementRepository<OnlineBookRequest> OnlineBookRequestRepository
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _OnlineBookRequestRepository = OnlineBookRequestRepository;
        }
          
        public async Task<Unit> Handle(UserOnlineBookRequest request, CancellationToken cancellationToken)
        {
            var requestStatus = 0;
            var OnlineBookRequest = new OnlineBookRequest();

            OnlineBookRequest.BookInformationId = request.BookInformationId;
            OnlineBookRequest.MemberInfoId = request.MemberInfoId;
            OnlineBookRequest.RequestStatus = 0;
            OnlineBookRequest.CancelStatus = 0;
            OnlineBookRequest.IssueStatus = 0;
            OnlineBookRequest.MenuPosition = 0;
            OnlineBookRequest.IsActive = true;

            //get issuestatus count and set requeststatus
            var issueStatusCount = await _OnlineBookRequestRepository.FilterAsync(x => x.BookInformationId == request.BookInformationId && x.IssueStatus == 0 && x.CancelStatus == 0);
            if (issueStatusCount.Count > 0)
            {
                requestStatus = issueStatusCount.Count + 1;
            }

            //get accession no and baseschoolnameid
            var book = await _unitOfWork.Repository<BookInformation>().Get(request.BookInformationId);
            OnlineBookRequest.BaseSchoolNameId = book.BaseSchoolNameId;
            OnlineBookRequest.AccessionNo = book.AccessionNo;
            OnlineBookRequest.RequestDate = DateTime.Now;
            if(requestStatus == 0)
            {
                OnlineBookRequest.RequestStatus = 1;
            }
            else
            {
                OnlineBookRequest.RequestStatus = requestStatus;
            }

            await _unitOfWork.Repository<OnlineBookRequest>().Add(OnlineBookRequest);

            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            var bookInformation = await _unitOfWork.Repository<BookInformation>().Get(request.BookInformationId);

            bookInformation.CountOnlineRequest += 1;


            await _unitOfWork.Repository<BookInformation>().Update(bookInformation);
            await _unitOfWork.Save();


            return Unit.Value;
        }
    }
}
