using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BookInformations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BookInformations.Handlers.Commands
{
    public class DeleteBookInformationCommandHandler : IRequestHandler<DeleteBookInformationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBookInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
                 
        public async Task<BaseCommandResponse> Handle(DeleteBookInformationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var BookInformation = await _unitOfWork.Repository<BookInformation>().Get(request.BookInformationId);

            if (BookInformation == null)
                throw new NotFoundException(nameof(BookInformation), request.BookInformationId);

            try
            {
                await _unitOfWork.Repository<BookInformation>().Delete(BookInformation);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                response.Id = 5;
            }
           return response;
        }
    }
}
