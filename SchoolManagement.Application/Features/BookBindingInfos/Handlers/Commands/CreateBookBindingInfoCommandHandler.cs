using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BookBindingInfo.Validators;
using SchoolManagement.Application.Features.BookBindingInfos.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookBindingInfos.Handlers.Commands
{
    public class CreateBookBindingInfoCommandHandler : IRequestHandler<CreateBookBindingInfoCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<OnlineBookRequest> _OnlineBookRequestRepository;

        public CreateBookBindingInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ISchoolManagementRepository<OnlineBookRequest> onlineBookRequestRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _OnlineBookRequestRepository = onlineBookRequestRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateBookBindingInfoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBookBindingInfoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BookBindingInfoDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BookBindingInfo = _mapper.Map<BookBindingInfo>(request.BookBindingInfoDto);

                BookBindingInfo = await _unitOfWork.Repository<BookBindingInfo>().Add(BookBindingInfo);
                BookBindingInfo.Date = BookBindingInfo.Date.Value.AddDays(1.0);
                await _unitOfWork.Save();


                var bookInfo = await _unitOfWork.Repository<BookInformation>().Get((int)BookBindingInfo.BookInformationId);
                bookInfo.BookBindingStatus = 1;
                bookInfo.IssueStatus = 2;
                bookInfo.CountOnlineRequest = 0;

                await _unitOfWork.Repository<BookInformation>().Update(bookInfo);
                await _unitOfWork.Save();

                IList<OnlineBookRequest> OnlineBookRequests = _OnlineBookRequestRepository.FilterWithInclude(x => x.BookInformationId == BookBindingInfo.BookInformationId && x.IssueStatus == 0 && x.CancelStatus == 0).OrderBy(x => x.RequestDate).ToList();
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


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BookBindingInfo.BookBindingInfoId;
            }

            return response;
        }
    }
}
