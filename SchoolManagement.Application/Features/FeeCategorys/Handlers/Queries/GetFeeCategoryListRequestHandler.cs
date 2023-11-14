using SchoolManagement.Application.Features.FeeCategorys.Requests.Queries;
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
using SchoolManagement.Application.DTOs.FeeCategory;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.FeeCategorys.Handlers.Queries
{
    public class GetFeeCategoryListRequestHandler : IRequestHandler<GetFeeCategoryListRequest, PagedResult<FeeCategoryDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.FeeCategory> _FeeCategoryRepository;

        private readonly IMapper _mapper;

        public GetFeeCategoryListRequestHandler(ISchoolManagementRepository<FeeCategory> FeeCategoryRepository, IMapper mapper)
        {
            _FeeCategoryRepository = FeeCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<FeeCategoryDto>> Handle(GetFeeCategoryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<FeeCategory> FeeCategorys = _FeeCategoryRepository.FilterWithInclude(x => (x.FeeCategoryName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = FeeCategorys.Count();
            FeeCategorys = FeeCategorys.OrderByDescending(x => x.FeeCategoryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var FeeCategoryDtos = _mapper.Map<List<FeeCategoryDto>>(FeeCategorys);
            var result = new PagedResult<FeeCategoryDto>(FeeCategoryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
