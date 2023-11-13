using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OnlineChat.Validators;
using SchoolManagement.Application.Features.OnlineChats.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineChats.Handlers.Commands
{
    public class CreateOnlineChatCommandHandler : IRequestHandler<CreateOnlineChatCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOnlineChatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateOnlineChatCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateOnlineChatDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OnlineChatDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var OnlineChat = _mapper.Map<OnlineChat>(request.OnlineChatDto);

                OnlineChat = await _unitOfWork.Repository<OnlineChat>().Add(OnlineChat);
                await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = OnlineChat.OnlineChatId;
            }

            return response;
        }
    }
}
