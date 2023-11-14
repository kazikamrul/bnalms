using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.OnlineChat.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OnlineChats.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineChats.Handlers.Commands
{
    public class UpdateOnlineChatCommandHandler : IRequestHandler<UpdateOnlineChatCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOnlineChatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOnlineChatCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOnlineChatDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.OnlineChatDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var OnlineChat = await _unitOfWork.Repository<OnlineChat>().Get(request.OnlineChatDto.OnlineChatId);

            if (OnlineChat is null)
                throw new NotFoundException(nameof(OnlineChat), request.OnlineChatDto.OnlineChatId);

            _mapper.Map(request.OnlineChatDto, OnlineChat);

            await _unitOfWork.Repository<OnlineChat>().Update(OnlineChat);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
