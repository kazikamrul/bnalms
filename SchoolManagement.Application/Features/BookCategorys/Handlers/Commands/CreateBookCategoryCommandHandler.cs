using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BookCategory.Validators;
using SchoolManagement.Application.Features.BookCategorys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookCategorys.Handlers.Commands
{
    public class CreateBookCategoryCommandHandler : IRequestHandler<CreateBookCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBookCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBookCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBookCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BookCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BookCategory = _mapper.Map<BookCategory>(request.BookCategoryDto);

                BookCategory = await _unitOfWork.Repository<BookCategory>().Add(BookCategory);
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
                response.Id = BookCategory.BookCategoryId;
            }

            return response;
        }
    }
}
