using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandBook.Validators;
using SchoolManagement.Application.Features.DemandBooks.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DemandBooks.Handlers.Commands
{
    public class CreateDemandBookCommandHandler : IRequestHandler<CreateDemandBookCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDemandBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDemandBookCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDemandBookDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DemandBookDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var DemandBook = _mapper.Map<DemandBook>(request.DemandBookDto);

                DemandBook = await _unitOfWork.Repository<DemandBook>().Add(DemandBook);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = DemandBook.DemandBookId;
            }

            return response;
        }
    }
}
