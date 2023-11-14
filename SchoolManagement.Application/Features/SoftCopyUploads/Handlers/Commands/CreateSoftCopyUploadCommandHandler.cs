using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SoftCopyUpload.Validators;
using SchoolManagement.Application.Features.SoftCopyUploads.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SoftCopyUploads.Handlers.Commands
{
    public class CreateSoftCopyUploadCommandHandler : IRequestHandler<CreateSoftCopyUploadCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSoftCopyUploadCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSoftCopyUploadCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSoftCopyUploadDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SoftCopyUploadDto);

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

                if (request.SoftCopyUploadDto.Doc != null)
                {

                    var fileName = Path.GetFileName(request.SoftCopyUploadDto.Doc.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\soft-copy-upload", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.SoftCopyUploadDto.Doc.CopyToAsync(fileSteam);
                    }


                }
                var SoftCopyUpload = _mapper.Map<SoftCopyUpload>(request.SoftCopyUploadDto);
                SoftCopyUpload.StorePDFFile = request.SoftCopyUploadDto.StorePDFFile ?? "files/soft-copy-upload/" + uniqueFileName;
                SoftCopyUpload = await _unitOfWork.Repository<SoftCopyUpload>().Add(SoftCopyUpload);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SoftCopyUpload.SoftCopyUploadId;
            }

            return response;
        }
    }
}
