using AutoMapper;
using SchoolManagement.Application.DTOs.VideoFile.Validators;
using SchoolManagement.Application.Features.VideoFiles.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.VideoFiles.Handlers.Commands
{
    public class CreateVideoFileCommandHandler : IRequestHandler<CreateVideoFileCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateVideoFileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateVideoFileCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateVideoFileDtoValidator();
            var validationResult = await validator.ValidateAsync(request.VideoFileDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                /////// File Upload //////////
                ///
                string uniqueFileName = null;

                if (request.VideoFileDto.Doc != null)
                {

                    var fileName = Path.GetFileName(request.VideoFileDto.Doc.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\video-files", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.VideoFileDto.Doc.CopyToAsync(fileSteam);
                    }


                }

                ////
                //  DateTime? d = request.TraineeBioDataGeneralInfoDto.DateOfBirth.ConvertToDateTime();

                var VideoFiles = _mapper.Map<VideoFile>(request.VideoFileDto);

                VideoFiles.DocumentLink = request.VideoFileDto.DocumentLink ?? "files/video-files/" + uniqueFileName;

                // var VideoFiles = _mapper.Map<VideoFile>(request.VideoFileDto);

                VideoFiles = await _unitOfWork.Repository<VideoFile>().Add(VideoFiles);
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
                response.Id = VideoFiles.VideoFileId;
            }

            return response;
        }
    }
}
