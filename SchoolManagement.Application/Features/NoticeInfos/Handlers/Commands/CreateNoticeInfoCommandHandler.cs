using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NoticeInfo.Validators;
using SchoolManagement.Application.Features.NoticeInfos.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NoticeInfos.Handlers.Commands
{
    public class CreateNoticeInfoCommandHandler : IRequestHandler<CreateNoticeInfoCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateNoticeInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateNoticeInfoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateNoticeInfoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.NoticeInfoDto);

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

                if (request.NoticeInfoDto.Doc != null)
                {

                    var fileName = Path.GetFileName(request.NoticeInfoDto.Doc.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\notice-infos", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.NoticeInfoDto.Doc.CopyToAsync(fileSteam);
                    }


                }
                var NoticeInfo = _mapper.Map<NoticeInfo>(request.NoticeInfoDto);
                NoticeInfo.UploadPDFFile = request.NoticeInfoDto.UploadPDFFile ?? "files/notice-infos/" + uniqueFileName;
                NoticeInfo = await _unitOfWork.Repository<NoticeInfo>().Add(NoticeInfo);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = NoticeInfo.NoticeInfoId;
            }

            return response;
        }
    }
}
