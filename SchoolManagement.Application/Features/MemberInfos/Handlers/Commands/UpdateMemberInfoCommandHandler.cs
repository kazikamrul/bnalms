using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.MemberInfos.Requests.Commands;
using SchoolManagement.Application.DTOs.MemberInfo.Validators;

namespace SchoolManagement.Application.Features.MemberInfos.Handlers.Commands
{
    public class UpdateMemberInfoCommandHandler : IRequestHandler<UpdateMemberInfoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMemberInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMemberInfoCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMemberInfoDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CreateMemberInfoDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var MemberInfo = await _unitOfWork.Repository<MemberInfo>().Get(request.CreateMemberInfoDto.MemberInfoId);

            if (MemberInfo is null)
                throw new NotFoundException(nameof(MemberInfo), request.CreateMemberInfoDto.MemberInfoId);

            /////// Image Upload //////////
            ///
            string uniqueFileName = null;

            if (request.CreateMemberInfoDto.Photo != null)
            {

                var fileName = Path.GetFileName(request.CreateMemberInfoDto.Photo.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\member-infos", uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.CreateMemberInfoDto.Photo.CopyToAsync(fileSteam);
                }


            }
            _mapper.Map(request.CreateMemberInfoDto, MemberInfo);
            MemberInfo.ImageUrl = request.CreateMemberInfoDto.Photo != null ? "files/member-infos/" + uniqueFileName : MemberInfo.ImageUrl.Replace("https://localhost:44395/Content/", String.Empty);

            

            await _unitOfWork.Repository<MemberInfo>().Update(MemberInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
