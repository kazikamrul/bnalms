using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.SoftCopyUploads.Requests.Commands;
using SchoolManagement.Application.DTOs.SoftCopyUpload.Validators;

namespace SchoolManagement.Application.Features.SoftCopyUploads.Handlers.Commands
{
    public class UpdateSoftCopyUploadCommandHandler : IRequestHandler<UpdateSoftCopyUploadCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSoftCopyUploadCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSoftCopyUploadCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSoftCopyUploadDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CreateSoftCopyUploadDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SoftCopyUpload = await _unitOfWork.Repository<SoftCopyUpload>().Get(request.CreateSoftCopyUploadDto.SoftCopyUploadId);

            if (SoftCopyUpload is null)
                throw new NotFoundException(nameof(SoftCopyUpload), request.CreateSoftCopyUploadDto.SoftCopyUploadId);
            
            /////// Image Upload //////////
            ///
            string uniqueFileName = null;

            if (request.CreateSoftCopyUploadDto.Doc != null)
            {

                var fileName = Path.GetFileName(request.CreateSoftCopyUploadDto.Doc.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\soft-copy-upload", uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.CreateSoftCopyUploadDto.Doc.CopyToAsync(fileSteam);
                }


            }
            _mapper.Map(request.CreateSoftCopyUploadDto, SoftCopyUpload);
            SoftCopyUpload.StorePDFFile = request.CreateSoftCopyUploadDto.Doc != null ? "files/soft-copy-upload/" + uniqueFileName : SoftCopyUpload.StorePDFFile.Replace("https://localhost:44395/Content/", String.Empty);
            await _unitOfWork.Repository<SoftCopyUpload>().Update(SoftCopyUpload);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
