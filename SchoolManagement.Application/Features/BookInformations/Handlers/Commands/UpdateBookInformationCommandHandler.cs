using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BookInformations.Requests.Commands;
using SchoolManagement.Application.DTOs.BookInformation.Validators;

namespace SchoolManagement.Application.Features.BookInformations.Handlers.Commands
{
    public class UpdateBookInformationCommandHandler : IRequestHandler<UpdateBookInformationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookInformationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBookInformationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CreateBookInformationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BookInformation = await _unitOfWork.Repository<BookInformation>().Get(request.CreateBookInformationDto.BookInformationId);

            if (BookInformation is null)
                throw new NotFoundException(nameof(BookInformation), request.CreateBookInformationDto.BookInformationId);

            /////// Image Upload //////////
            ///
            string uniqueFileName = null;

            if (request.CreateBookInformationDto.Photo != null)
            {

                var fileName = Path.GetFileName(request.CreateBookInformationDto.Photo.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\book-informations", uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.CreateBookInformationDto.Photo.CopyToAsync(fileSteam);
                }


            }
            _mapper.Map(request.CreateBookInformationDto, BookInformation);
            if (request.CreateBookInformationDto.DamageDate != null)
            {
                BookInformation.DamageDate = BookInformation.DamageDate.Value.AddDays(1.0);
            }

            BookInformation.CoverImage = request.CreateBookInformationDto.Photo != null ? "files/book-informations/" + uniqueFileName : BookInformation.CoverImage.Replace("https://localhost:44395/Content/", String.Empty);
            await _unitOfWork.Repository<BookInformation>().Update(BookInformation);
           // BookInformation.DamageDate = BookInformation.DamageDate.Value.AddDays(1.0);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
