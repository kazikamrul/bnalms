using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MemberInfo.Validators;
using SchoolManagement.Application.Features.MemberInfos.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MemberInfos.Handlers.Commands
{
    public class CreateMemberInfoCommandHandler : IRequestHandler<CreateMemberInfoCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMemberInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateMemberInfoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMemberInfoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MemberInfoDto);

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

                if (request.MemberInfoDto.Photo != null)
                {

                    var fileName = Path.GetFileName(request.MemberInfoDto.Photo.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\member-infos", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.MemberInfoDto.Photo.CopyToAsync(fileSteam);
                    }


                }
                var MemberInfo = _mapper.Map<MemberInfo>(request.MemberInfoDto);
                MemberInfo.ImageUrl = request.MemberInfoDto.ImageUrl ?? "files/member-infos/" + uniqueFileName;
                MemberInfo.EmpStatus = 0;
                MemberInfo = await _unitOfWork.Repository<MemberInfo>().Add(MemberInfo);
                MemberInfo.MemberShipDate = MemberInfo.MemberShipDate.Value.AddDays(1.0);
                MemberInfo.MemberExpireDate = MemberInfo.MemberExpireDate.Value.AddDays(1.0);
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
                response.Id = MemberInfo.MemberInfoId;
            }

            return response;
        }
    }
}
