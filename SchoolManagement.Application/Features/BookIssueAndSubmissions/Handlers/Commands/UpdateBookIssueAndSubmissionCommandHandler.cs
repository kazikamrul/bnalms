using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs.BookIssueAndSubmission.Validators;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Commands;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Handlers.Commands
{
    public class UpdateBookIssueAndSubmissionCommandHandler : IRequestHandler<UpdateBookIssueAndSubmissionCommand, Unit>
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<OnlineBookRequest> _OnlineBookRequestRepository;

        public UpdateBookIssueAndSubmissionCommandHandler(ISchoolManagementRepository<OnlineBookRequest> OnlineBookRequestRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _OnlineBookRequestRepository = OnlineBookRequestRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookIssueAndSubmissionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBookIssueAndSubmissionDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BookIssueAndSubmissionDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BookIssueAndSubmission = await _unitOfWork.Repository<BookIssueAndSubmission>().Get(request.BookIssueAndSubmissionDto.BookIssueAndSubmissionId);

            if (BookIssueAndSubmission is null)
                throw new NotFoundException(nameof(BookIssueAndSubmission), request.BookIssueAndSubmissionDto.BookIssueAndSubmissionId);

            if(int.Parse(request.BookIssueAndSubmissionDto.IsDamage) == 1)
            {
                BookIssueAndSubmission.BorrowerDamageStatus = 1;
                BookIssueAndSubmission.ReturnStatus = 1;
                BookIssueAndSubmission.BorrowerDamageDate = DateTime.Now;
                BookIssueAndSubmission.BorrowerDamageFineAmount = request.BookIssueAndSubmissionDto.BorrowerDamageFineAmount;
                BookIssueAndSubmission.BorrowerDamageRemarks = request.BookIssueAndSubmissionDto.BorrowerDamageRemarks;

                var bookInformation = await _unitOfWork.Repository<BookInformation>().Get(request.BookIssueAndSubmissionDto.BookInformationId);
                bookInformation.BorrowerDamageStatus = 1;
                bookInformation.IssueStatus = 0;
                bookInformation.BorrowerDamageDate = DateTime.Now;
                bookInformation.BorrowerDamageFineAmount = request.BookIssueAndSubmissionDto.BorrowerDamageFineAmount;
                bookInformation.BorrowerDamageRemarks = request.BookIssueAndSubmissionDto.BorrowerDamageRemarks;
                bookInformation.MemberInfoId = request.BookIssueAndSubmissionDto.MemberInfoId;
                bookInformation.BookIssueAndSubmissionId = request.BookIssueAndSubmissionDto.BookIssueAndSubmissionId;

                await _unitOfWork.Repository<BookInformation>().Update(bookInformation);
                await _unitOfWork.Repository<BookIssueAndSubmission>().Update(BookIssueAndSubmission);
                await _unitOfWork.Save();

                IList<OnlineBookRequest> OnlineBookRequests = _OnlineBookRequestRepository.FilterWithInclude(x => x.BookInformationId == request.BookIssueAndSubmissionDto.BookInformationId && x.IssueStatus == 0 && x.CancelStatus == 0).OrderBy(x => x.RequestDate).ToList();
                //var OnlineBookRequestDtos = _mapper.Map<List<OnlineBookRequestDto>>(OnlineBookRequests);
                //var initial = 1;
                foreach (var item in OnlineBookRequests)
                {
                    item.RequestStatus = 0;
                    item.CancelStatus = 1;
                    await _unitOfWork.Repository<OnlineBookRequest>().Update(item);
                    await _unitOfWork.Save();

                    //initial++;
                }

            }
            else
            {
                _mapper.Map(request.BookIssueAndSubmissionDto, BookIssueAndSubmission);

                await _unitOfWork.Repository<BookIssueAndSubmission>().Update(BookIssueAndSubmission);
                await _unitOfWork.Save();
            }
            

            return Unit.Value;
        }
    }
}
