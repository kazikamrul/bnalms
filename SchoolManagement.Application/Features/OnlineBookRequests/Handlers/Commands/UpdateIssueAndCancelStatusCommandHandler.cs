using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.OnlineBookRequests.Requests.Commands;
using SchoolManagement.Application.DTOs.OnlineBookRequest.Validators;
using SchoolManagement.Application.DTOs.OnlineBookRequest;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Handlers.Commands
{
    public class UpdateIssueAndCancelStatusCommandHandler : IRequestHandler<UpdateIssueAndCancelStatusCommand, Unit>
    {
        private readonly ISchoolManagementRepository<OnlineBookRequest> _OnlineBookRequestRepository;
        private readonly ISchoolManagementRepository<BookInformation> _BookInformationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateIssueAndCancelStatusCommandHandler(ISchoolManagementRepository<BookInformation> BookInformationRepository,ISchoolManagementRepository<OnlineBookRequest> OnlineBookRequestRepository,IUnitOfWork unitOfWork, IMapper mapper)
        {
            _OnlineBookRequestRepository = OnlineBookRequestRepository;
            _BookInformationRepository = BookInformationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateIssueAndCancelStatusCommand request, CancellationToken cancellationToken)
        {
            var bookInformation = _BookInformationRepository.FinedOneInclude(x => x.BookInformationId == request.BookInformationId);
            bookInformation.CountOnlineRequest -= 1;

            await _unitOfWork.Repository<BookInformation>().Update(bookInformation);
            await _unitOfWork.Save();


            var OnlineBookRequest = await _unitOfWork.Repository<OnlineBookRequest>().Get(request.OnlineBookRequestId);

            if (OnlineBookRequest is null)
                throw new NotFoundException(nameof(OnlineBookRequest), request.OnlineBookRequestId);

            OnlineBookRequest.RequestStatus = 0;
            OnlineBookRequest.CancelStatus = 1;

            await _unitOfWork.Repository<OnlineBookRequest>().Update(OnlineBookRequest);
            await _unitOfWork.Save();


            IList<OnlineBookRequest> OnlineBookRequests = _OnlineBookRequestRepository.FilterWithInclude(x => x.BookInformationId == request.BookInformationId && x.IssueStatus == 0 && x.CancelStatus == 0).OrderBy(x => x.RequestDate).ToList();
            //var OnlineBookRequestDtos = _mapper.Map<List<OnlineBookRequestDto>>(OnlineBookRequests);
            var initial = 1;
            foreach (var item in OnlineBookRequests)
            {
                item.RequestStatus = initial;
                await _unitOfWork.Repository<OnlineBookRequest>().Update(item);
                await _unitOfWork.Save();

                initial++;
            }

            return Unit.Value;
        }
    }
}
