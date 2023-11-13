using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BookIssueAndSubmission.Validators;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Handlers.Commands
{
    public class CreateBookIssueAndSubmissionCommandHandler : IRequestHandler<CreateBookIssueAndSubmissionCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BookInformation> _BookInformationRepository;
        private readonly ISchoolManagementRepository<OnlineBookRequest> _OnlineBookRequestRepository;

        public CreateBookIssueAndSubmissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,
            ISchoolManagementRepository<BookInformation> BookInformationRepository,
            ISchoolManagementRepository<OnlineBookRequest> OnlineBookRequestRepository
            )
        {
            _BookInformationRepository = BookInformationRepository;
            _OnlineBookRequestRepository = OnlineBookRequestRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBookIssueAndSubmissionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBookIssueAndSubmissionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BookIssueAndSubmissionDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BookIssueAndSubmission = _mapper.Map<BookIssueAndSubmission>(request.BookIssueAndSubmissionDto);

                //For get Book Information Id
                var BookInfo = _BookInformationRepository.FinedOneInclude(x => x.BookInformationId == request.BookIssueAndSubmissionDto.BookInformationId);
                BookIssueAndSubmission.RowInfoId = BookInfo.RowInfoId;
                BookIssueAndSubmission.ShelfInfoId = BookInfo.ShelfInfoId;
                BookIssueAndSubmission.ReturnStatus = 0;
                BookIssueAndSubmission.BorrowerDamageStatus = 0;
                BookIssueAndSubmission.IssueDate = DateTime.Now;
                BookIssueAndSubmission.ReturnDate = DateTime.Now.AddDays(7);
                

                BookIssueAndSubmission = await _unitOfWork.Repository<BookIssueAndSubmission>().Add(BookIssueAndSubmission);
                await _unitOfWork.Save();

                var onlineBookRequest = await _unitOfWork.Repository<OnlineBookRequest>().Get(request.BookIssueAndSubmissionDto.OnlineBookRequestId.Value);
                onlineBookRequest.IssueStatus = 1;
                onlineBookRequest.RequestStatus = 0;

                await _unitOfWork.Repository<OnlineBookRequest>().Update(onlineBookRequest);
                await _unitOfWork.Save();

                var bookInformation = await _unitOfWork.Repository<BookInformation>().Get(request.BookIssueAndSubmissionDto.BookInformationId);
                bookInformation.IssueStatus = 1;
                bookInformation.CountOnlineRequest -= 1;

                await _unitOfWork.Repository<BookInformation>().Update(bookInformation);
                await _unitOfWork.Save();


                IList<OnlineBookRequest> OnlineBookRequests = _OnlineBookRequestRepository.FilterWithInclude(x => x.BookInformationId == request.BookIssueAndSubmissionDto.BookInformationId && x.IssueStatus == 0 && x.CancelStatus == 0).OrderBy(x => x.RequestDate).ToList();
                //var OnlineBookRequestDtos = _mapper.Map<List<OnlineBookRequestDto>>(OnlineBookRequests);
                var initial = 1;
                foreach (var item in OnlineBookRequests)
                {
                    item.RequestStatus = initial;
                    await _unitOfWork.Repository<OnlineBookRequest>().Update(item);
                    await _unitOfWork.Save();

                    initial++;
                }

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BookIssueAndSubmission.BookIssueAndSubmissionId;
            }

            return response;
        }
    }
}
