using SchoolManagement.Application.Features.SecurityQuestions.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.SecurityQuestion;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SecurityQuestions.Handlers.Queries
{
    public class GetSecurityQuestionListRequestHandler : IRequestHandler<GetSecurityQuestionListRequest, PagedResult<SecurityQuestionDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.SecurityQuestion> _SecurityQuestionRepository;

        private readonly IMapper _mapper;

        public GetSecurityQuestionListRequestHandler(ISchoolManagementRepository<SecurityQuestion> SecurityQuestionRepository, IMapper mapper)
        {
            _SecurityQuestionRepository = SecurityQuestionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SecurityQuestionDto>> Handle(GetSecurityQuestionListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SecurityQuestion> SecurityQuestions = _SecurityQuestionRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = SecurityQuestions.Count();
            SecurityQuestions = SecurityQuestions.OrderByDescending(x => x.SecurityQuestionId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SecurityQuestionDtos = _mapper.Map<List<SecurityQuestionDto>>(SecurityQuestions);
            var result = new PagedResult<SecurityQuestionDto>(SecurityQuestionDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
