using SchoolManagement.Application.Features.MemberCategorys.Requests.Queries;
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
using SchoolManagement.Application.DTOs.MemberCategory;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MemberCategorys.Handlers.Queries
{
    public class GetMemberCategoryListRequestHandler : IRequestHandler<GetMemberCategoryListRequest, PagedResult<MemberCategoryDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.MemberCategory> _MemberCategoryRepository;

        private readonly IMapper _mapper;

        public GetMemberCategoryListRequestHandler(ISchoolManagementRepository<MemberCategory> MemberCategoryRepository, IMapper mapper)
        {
            _MemberCategoryRepository = MemberCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MemberCategoryDto>> Handle(GetMemberCategoryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<MemberCategory> MemberCategorys = _MemberCategoryRepository.FilterWithInclude(x => (x.MemberCategoryName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = MemberCategorys.Count();
            MemberCategorys = MemberCategorys.OrderByDescending(x => x.MemberCategoryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MemberCategoryDtos = _mapper.Map<List<MemberCategoryDto>>(MemberCategorys);
            var result = new PagedResult<MemberCategoryDto>(MemberCategoryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
