using SchoolManagement.Application.Features.AuthorityCategorys.Requests.Queries;
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
using SchoolManagement.Application.DTOs.AuthorityCategory;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AuthorityCategorys.Handlers.Queries
{
    public class GetAuthorityCategoryListRequestHandler : IRequestHandler<GetAuthorityCategoryListRequest, PagedResult<AuthorityCategoryDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.AuthorityCategory> _AuthorityCategoryRepository;

        private readonly IMapper _mapper;

        public GetAuthorityCategoryListRequestHandler(ISchoolManagementRepository<AuthorityCategory> AuthorityCategoryRepository, IMapper mapper)
        {
            _AuthorityCategoryRepository = AuthorityCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AuthorityCategoryDto>> Handle(GetAuthorityCategoryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<AuthorityCategory> AuthorityCategorys = _AuthorityCategoryRepository.FilterWithInclude(x => (x.AuthorCategoryName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = AuthorityCategorys.Count();
            AuthorityCategorys = AuthorityCategorys.OrderByDescending(x => x.AuthorityCategoryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AuthorityCategoryDtos = _mapper.Map<List<AuthorityCategoryDto>>(AuthorityCategorys);
            var result = new PagedResult<AuthorityCategoryDto>(AuthorityCategoryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
