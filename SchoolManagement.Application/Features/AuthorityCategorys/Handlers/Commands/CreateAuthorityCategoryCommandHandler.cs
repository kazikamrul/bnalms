﻿using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AuthorityCategory.Validators;
using SchoolManagement.Application.Features.AuthorityCategorys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.AuthorityCategorys.Handlers.Commands
{
    public class CreateAuthorityCategoryCommandHandler : IRequestHandler<CreateAuthorityCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAuthorityCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAuthorityCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateAuthorityCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AuthorityCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var AuthorityCategory = _mapper.Map<AuthorityCategory>(request.AuthorityCategoryDto);

                AuthorityCategory = await _unitOfWork.Repository<AuthorityCategory>().Add(AuthorityCategory);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = AuthorityCategory.AuthorityCategoryId;
            }

            return response;
        }
    }
}
