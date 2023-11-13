using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.NoticeInfos.Requests.Commands;
using SchoolManagement.Application.DTOs.NoticeInfo.Validators;

namespace SchoolManagement.Application.Features.NoticeInfos.Handlers.Commands
{
    public class UpdateNoticeInfoCommandHandler : IRequestHandler<UpdateNoticeInfoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateNoticeInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNoticeInfoCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateNoticeInfoDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CreateNoticeInfoDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var NoticeInfo = await _unitOfWork.Repository<NoticeInfo>().Get(request.CreateNoticeInfoDto.NoticeInfoId);

            if (NoticeInfo is null)
                throw new NotFoundException(nameof(NoticeInfo), request.CreateNoticeInfoDto.NoticeInfoId);

            /////// Image Upload //////////
            ///
            string uniqueFileName = null;

            if (request.CreateNoticeInfoDto.Doc != null)
            {

                var fileName = Path.GetFileName(request.CreateNoticeInfoDto.Doc.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\notice-infos", uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.CreateNoticeInfoDto.Doc.CopyToAsync(fileSteam);
                }


            }
            _mapper.Map(request.CreateNoticeInfoDto, NoticeInfo);
            NoticeInfo.UploadPDFFile = request.CreateNoticeInfoDto.Doc != null ? "files/notice-infos/" + uniqueFileName : NoticeInfo.UploadPDFFile.Replace("https://localhost:44395/Content/", String.Empty);
            await _unitOfWork.Repository<NoticeInfo>().Update(NoticeInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
