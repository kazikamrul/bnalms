using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BookTitleInfo.Validators;
using SchoolManagement.Application.Features.BookTitleInfos.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookTitleInfos.Handlers.Commands
{
    public class CreateBookTitleInfoCommandHandler : IRequestHandler<CreateBookTitleInfoCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBookTitleInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBookTitleInfoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBookTitleInfoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BookTitleInfoDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BookTitleInfo = _mapper.Map<BookTitleInfo>(request.BookTitleInfoDto);

                BookTitleInfo = await _unitOfWork.Repository<BookTitleInfo>().Add(BookTitleInfo);
                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
                


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BookTitleInfo.BookTitleInfoId;
            }

            return response;
        }
    }
}
