using SchoolManagement.Application.Features.Languages.Requests.Queries;
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
using SchoolManagement.Application.DTOs.Language;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Languages.Handlers.Queries
{
    public class GetLanguageListRequestHandler : IRequestHandler<GetLanguageListRequest, PagedResult<LanguageDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Language> _LanguageRepository;

        private readonly IMapper _mapper;

        public GetLanguageListRequestHandler(ISchoolManagementRepository<Language> LanguageRepository, IMapper mapper)
        {
            _LanguageRepository = LanguageRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<LanguageDto>> Handle(GetLanguageListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Language> Languages = _LanguageRepository.FilterWithInclude(x => (x.LanguageName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Languages.Count();
            Languages = Languages.OrderByDescending(x => x.LanguageId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var LanguageDtos = _mapper.Map<List<LanguageDto>>(Languages);
            var result = new PagedResult<LanguageDto>(LanguageDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
