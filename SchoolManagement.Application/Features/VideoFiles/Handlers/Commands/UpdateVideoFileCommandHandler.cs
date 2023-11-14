using AutoMapper;
using SchoolManagement.Application.DTOs.VideoFile.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.VideoFiles.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.VideoFiles.Handlers.Commands
{
    public class UpdateVideoFileCommandHandler : IRequestHandler<UpdateVideoFileCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateVideoFileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateVideoFileCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateVideoFileDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateVideoFileDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var VideoFiles = await _unitOfWork.Repository<VideoFile>().Get(request.CreateVideoFileDto.VideoFileId);

            if (VideoFiles is null)
                throw new NotFoundException(nameof(VideoFile), request.CreateVideoFileDto.VideoFileId);

            /////// File Upload //////////
            ///
            string uniqueFileName = null;

            if (request.CreateVideoFileDto.Doc != null)
            {

                var fileName = Path.GetFileName(request.CreateVideoFileDto.Doc.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\video-files", uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.CreateVideoFileDto.Doc.CopyToAsync(fileSteam);
                }

                // request.UpdateTraineeBIODataGeneralInfoDto.BnaPhotoUrl = "images/profile/" + uniqueFileName;
            }

            ////
            //  DateTime? d = request.TraineeBioDataGeneralInfoDto.DateOfBirth.ConvertToDateTime();




            _mapper.Map(request.CreateVideoFileDto, VideoFiles);

            //  request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl = request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl ?? TraineeBioDataGeneralInfos.BnaPhotoUrl;


            // TraineeBioDataGeneralInfos.BnaPhotoUrl = request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl ?? "images/profile/" + uniqueFileName;
            VideoFiles.DocumentLink = request.CreateVideoFileDto.Doc != null ? "files/video-files/" + uniqueFileName : VideoFiles.DocumentLink.Replace("https://localhost:44395/Content/", String.Empty);




            await _unitOfWork.Repository<VideoFile>().Update(VideoFiles);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
