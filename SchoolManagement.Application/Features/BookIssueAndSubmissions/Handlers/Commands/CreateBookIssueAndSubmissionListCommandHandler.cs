using AutoMapper;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaExamMarks.Handlers.Commands
{
    public class CreateBookIssueAndSubmissionListCommandHandler : IRequestHandler<CreateBookIssueAndSubmissionListCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBookIssueAndSubmissionListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBookIssueAndSubmissionListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            //var BnaExamMarks = _mapper.Map<List<BnaExamMark>>(request.BnaExamMarkListDto);
            var bookIssues = request.BookIssueAndSubmissionDto;

            
            var bookIssueList = bookIssues.IssueListForm.Select(x => new BookIssueAndSubmission()
            {
                    BaseSchoolNameId = bookIssues.BaseSchoolNameId,
                    MemberInfoId = bookIssues.MemberInfoId,
                    BookInformationId = x.BookInformationId,
                    ShelfInfoId = x.ShelfInfoId,
                    RowInfoId = x.RowInfoId,
                    IssueDate = x.IssueDate,
                    ReturnDate = x.ReturnDate,
                    SubmissionDate = bookIssues.SubmissionDate,
                    FineForLate = bookIssues.FineForLate,
                    FineForDamage = bookIssues.FineForDamage,
                    IsDamage = bookIssues.IsDamage,
                    BookStatus = bookIssues.BookStatus,
                    CancelDate = bookIssues.CancelDate,
                    CancelId = bookIssues.CancelId,
                    OnlineRequested = bookIssues.OnlineRequested,
                    AcceptDate = bookIssues.AcceptDate,
                    RequestDate = bookIssues.RequestDate,
                    RemarksForIssue = bookIssues.RemarksForIssue,
                    ReturnStatus = 0,
                    BorrowerDamageStatus = 0,
                    MailTracking = bookIssues.MailTracking,
                    Seen = bookIssues.Seen,
                    RemarksForSubmission = bookIssues.RemarksForSubmission,
                    IssuedBy = bookIssues.IssuedBy,
                });

                await _unitOfWork.Repository<BookIssueAndSubmission>().AddRangeAsync(bookIssueList);
                await _unitOfWork.Save();


            foreach (var item in bookIssueList)
            {
                var bookInfo = await _unitOfWork.Repository<BookInformation>().Get((int)item.BookInformationId);
                bookInfo.IssueStatus = 1;
                bookInfo.MemberInfoId = item.MemberInfoId;

                var onlineBookRequest = _unitOfWork.Repository<OnlineBookRequest>().FinedOneInclude(x => x.BookInformationId == item.BookInformationId && x.MemberInfoId == item.MemberInfoId && x.IssueStatus == 0);
                
                if(onlineBookRequest != null)
                {
                    onlineBookRequest.IssueStatus = 1;
                    await _unitOfWork.Repository<OnlineBookRequest>().Update(onlineBookRequest);
                    await _unitOfWork.Save();
                }
                
                await _unitOfWork.Repository<BookInformation>().Update(bookInfo);
                await _unitOfWork.Save();
            }

            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
