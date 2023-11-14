using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BookInformation.Validators;
using SchoolManagement.Application.Features.BookInformations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookInformations.Handlers.Commands
{
    public class CreateBookInformationCommandHandler : IRequestHandler<CreateBookInformationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBookInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBookInformationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBookInformationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BookInformationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
                
            {
                /////// Image Upload //////////
                ///
                string uniqueFileName = null;

                if (request.BookInformationDto.Photo != null)
                {

                    var fileName = Path.GetFileName(request.BookInformationDto.Photo.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\book-informations", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.BookInformationDto.Photo.CopyToAsync(fileSteam);
                    }


                }
                var BookInformation = _mapper.Map<BookInformation>(request.BookInformationDto);
                BookInformation.CoverImage = request.BookInformationDto.CoverImage ?? "files/book-informations/" + uniqueFileName;

                BookInformation = await _unitOfWork.Repository<BookInformation>().Add(BookInformation);
                BookInformation.AccessionDate = BookInformation.AccessionDate.Value.AddDays(1.0);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BookInformation.BookInformationId;
            }

            return response;
        }
    }
}
